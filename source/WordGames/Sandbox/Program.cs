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

            WordDictionary russianNouns = new WordDictionary(@"..\..\..\..\..\data\nouns.txt");
            AnyWordProvider anyWords = new AnyWordProvider();

            Field field = Field.From(@"..\..\..\..\..\data\fields\field1.txt", russianNouns);

            foreach (var path in field.GetAllPaths(Point.Zero, SearchDirection.All, 5))
            {
                var word = field.GetWord(path);
                Console.WriteLine(word);
            }

            Console.WriteLine("-all-");
            Console.ReadLine();
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

        static bool IsPointInsideField(Point point, int size)
        {
            return point.X >= 0 && point.X < size && point.Y >= 0 && point.Y < size;
        }
    }
}
