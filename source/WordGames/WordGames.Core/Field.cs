using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WordGames.Core
{
    public class Field
    {
        private char[,] _field;
        private readonly IWordProvider _wordProvider;

        public int Size { get { return _field.GetLength(0); } }
        public char this[int row, int column] { get { return _field[row, column]; } }

        public static Field From(string path, IWordProvider wordProvider)
        {
            var lines = File.ReadAllLines(path, Encoding.UTF8);
            return new Field(lines, wordProvider);
        }

        public Field(string[] lines, IWordProvider wordProvider)
        {
            if (lines == null || lines.Length < 2 || lines.Length != lines[0].Length)
                throw new ArgumentException();

            _wordProvider = wordProvider;

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
            return this.GetAllPaths(start, searchDirection, maxDepth, _wordProvider);
        }
        private IEnumerable<Path> GetAllPaths(Point start, SearchDirection searchDirection, int maxDepth, IWordProvider wordProvider)
        {
            List<Path> oldPaths = new List<Path>() { new Path() { start } };

            while (true)
            {
                List<Path> newPaths = new List<Path>();
                foreach (var path in oldPaths)
                {
                    var neighbours = path.Last.GetNeighbours(searchDirection);
                    for (int i = 0; i < neighbours.Length; i++)
                    {
                        if (!neighbours[i].IsInsideField(Size, Size))
                            continue;

                        if (!path.Contains(neighbours[i]))
                        {
                            var nPath = path.Extend(neighbours[i]);
                            if (wordProvider.StartsWith(this.GetWord(nPath)))
                                newPaths.Add(nPath);
                        }
                    }
                }

                foreach (var nPath in newPaths)
                {
                    if (wordProvider.Contains(this.GetWord(nPath)))
                        yield return nPath;
                }

                if (newPaths.Count == 0 || newPaths[0].Length >= maxDepth)
                    yield break;

                oldPaths = newPaths;
            }
        }

        public string GetWord(Path path)
        {
            char[] letters = new char[path.Length];
            
            for (int i = 0; i < path.Length; i++)
                letters[i] = _field[path[i].X, path[i].Y];
            
            return new string(letters);
        }
    }
}
