using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sandbox
{
    public class Field
    {
        private char[,] _field;

        public int Size { get { return _field.GetLength(0); } }
        public char this[int row, int column] { get { return _field[row, column]; } }

        public static Field From(string path)
        {
            var lines = File.ReadAllLines(path, Encoding.UTF8);
            return new Field(lines);
        }

        public Field(string[] lines)
        {
            if (lines == null || lines.Length < 2 || lines.Length != lines[0].Length)
                throw new ArgumentException();

            int size = lines.Length;

            _field = new char[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    _field[i, j] = lines[i][j];
        }

        public IEnumerable<Path> GetAllPaths(Point start, SearchDirection searchDirection)
        {
            return this.GetAllPaths(start, searchDirection, Size * Size);
        }
        public IEnumerable<Path> GetAllPaths(Point start, SearchDirection searchDirection, int maxDepth)
        {
            var trivialPath = new Path() { start };
            yield return trivialPath;

            List<Path> oldPaths = new List<Path>() { trivialPath };
            
            while (true)
            { 
                List<Path> newPaths = new List<Path>();
                foreach (var path in oldPaths)
                {
                    var neighbours = path.Last.GetNeighbours(searchDirection);
                    for (int i = 0; i < neighbours.Length; i++)
                    {
                        if (!neighbours[i].IsInside(Size, Size))
                            continue;

                        if (!path.Contains(neighbours[i]))
                        {
                            var p = ((Path)path.Clone());
                            p.Add(neighbours[i]);
                            newPaths.Add(p);
                        }
                    }
                }

                foreach (var nPath in newPaths)
                    yield return nPath;
                
                if (newPaths.Count == 0 || newPaths[0].Length >= maxDepth)
                    yield break;

                oldPaths = newPaths;
            }
        }
    }
}
