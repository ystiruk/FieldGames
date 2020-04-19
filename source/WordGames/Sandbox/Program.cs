using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Field field = Field.From(@"..\..\..\..\..\data\fields\field1.txt");

            foreach (var path in field.GetAllPaths(Point.Zero, SearchDirection.All))
            {
                var word = field.GetWord(path);
                Console.WriteLine(word);
            }

            Console.ReadLine();
        }

        static void Traverse(int[,] field, Point start, SearchDirection dir, out List<Path> paths)
        {
            paths = new List<Path>();
            paths.Add(new Path() { start });

            List<Path> oldPaths = new List<Path>(paths);
            List<Path> newPaths = null;
            do
            {
                newPaths = new List<Path>();
                foreach (var path in oldPaths)
                {
                    var neighbours = path.Last.GetNeighbours(dir);
                    for (int i = 0; i < neighbours.Length; i++)
                    {
                        if (!IsPointInsideField(neighbours[i], field.GetLength(0)))
                            continue;

                        if (!path.Contains(neighbours[i]))
                        {
                            var p = ((Path)path.Clone());
                            p.Add(neighbours[i]);
                            newPaths.Add(p);
                        }
                    }
                }
                paths.AddRange(newPaths);
                oldPaths = newPaths;
            } while (newPaths.Count > 0);
        }

        static void PrintPath(Path path)
        {
            Console.WriteLine(string.Join(" -> ", path));
        }

        static int[,] CreateField(int size)
        {
            int[,] field = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = i * size + j;
                }
            }

            return field;
        }

        static void PrintField(int[,] field)
        {
            int size = field.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(field[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void BFS(int[,] field, int startX, int startY)
        {
            int size = field.GetLength(0);
            int[,] visited = new int[size, size];

            Point start = new Point(startX, startY);
            List<Point> oldWave = new List<Point>() { start };
            visited[start.Y, start.X] = 1;

            List<Point> newWave;
            do
            {
                newWave = new List<Point>();
                foreach (var p in oldWave)
                {
                    //previsit
                    Console.WriteLine(p);

                    var next = p.GetNeighbours(SearchDirection.Cross);
                    for (int i = 0; i < next.Length; i++)
                    {
                        if (IsPointInsideField(next[i], size) && visited[next[i].Y, next[i].X] != 1)
                        {
                            visited[next[i].Y, next[i].X] = 1;
                            newWave.Add(next[i]);
                        }
                    }
                }

                oldWave = newWave;
                Console.WriteLine();
            }
            while (newWave.Count > 0);
        }

        public static bool IsPointInsideField(Point point, int size)
        {
            return point.X >= 0 && point.X < size && point.Y >= 0 && point.Y < size;
        }
    }
}
