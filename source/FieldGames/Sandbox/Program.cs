﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using FieldGames.Core;
using System.Diagnostics;
using FieldGames.WordByWord;
using FieldGames.TicTacToe;
using System.Threading.Tasks;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = "ниваптетьранмозкоысаерьтп";
            
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            WordDictionary russianNouns = new WordDictionary(@"..\..\..\..\..\data\nouns.txt");

            //Field field = Field.FromFile(@"..\..\..\..\..\data\fields\field1.txt", russianNouns);
            //Console.Write("Letters: ");
            //data = Console.ReadLine();

            WordByWordField field = new WordByWordField(data, russianNouns);

            Console.WriteLine(field);

            Stopwatch sw = new Stopwatch();
            sw.Start();

            HashSet<string> unique = new HashSet<string>();
            int cc = 1;

            for (int i = 0; i < field.Size; i++)
            {
                Parallel.For(0, field.Size, (j) =>
                {
                    var paths = field.GetAllPaths(new Point(i, j), SearchDirection.All);

                    foreach (var path in paths)
                    {
                        var word = field.GetWord(path);

                        if (unique.Add(word))
                            Console.WriteLine(cc++ + ") " + word);
                    }
                });
            }
            sw.Stop();

            Console.WriteLine("Top10:");
            foreach (var item in unique.OrderByDescending(x => x.Length).Take(10))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"-all- ({sw.ElapsedMilliseconds} ms.)");
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
