using FieldGames.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FieldGames.WordByWord
{
    public class WordByWordField
    {
        private char[,] _field;
        private readonly IWordProvider _wordProvider;

        public int Size { get { return _field.GetLength(0); } }
        public char this[int row, int column] { get { return _field[row, column]; } }

        public static WordByWordField FromFile(string path, IWordProvider wordProvider = null)
        {
            var lines = System.IO.File.ReadAllLines(path, Encoding.UTF8);
            return new WordByWordField(lines, wordProvider);
        }

        public WordByWordField(string[] lines, IWordProvider wordProvider)
        {
            if (lines == null || lines.Length < 2 || lines.Length != lines[0].Length)
                throw new ArgumentException();

            if (wordProvider == null)
                wordProvider = new AnyWordProvider();

            _wordProvider = wordProvider;

            int size = lines.Length;

            _field = new char[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    _field[i, j] = lines[i][j];
        }
        public WordByWordField(string letters, IWordProvider wordProvider) //TODO: refactor
        {
            if (wordProvider == null)
                wordProvider = new AnyWordProvider();

            _wordProvider = wordProvider;

            var size = (int)Math.Sqrt(letters.Length);

            string[] lines = new string[size];
            for (int i = 0; i < size; i++)
                lines[i] = letters.Substring(i * size, size);

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
        public string VisualizeWord(Path path)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    var c = (path.Contains(new Point(i, j)) ? _field[i, j] : ' ');
                    sb.Append(c);
                }
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    sb.Append(_field[i, j]);
                }
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
