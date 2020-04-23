using System;
using System.Collections.Generic;

namespace FieldGames.Core
{
    public abstract class Field<T> : IField<T>
    {
        protected T[,] field;

        public T this[int row, int column]
        {
            get => field[row, column];
            set => field[row, column] = value;
        }
        public int Height => field.GetLength(0);
        public int Width => field.GetLength(1);

        protected Field(int height, int width)
        {
            if (width <= 0) throw new ArgumentException(nameof(width));
            if (height <= 0) throw new ArgumentException(nameof(height));

            field = new T[height, width];
        }

        public IEnumerable<T> GetElements(Path path)
        {
            List<T> sequence = new List<T>(path.Length);
            
            foreach (var point in path)
                sequence.Add(field[point.X, point.Y]);
            
            return sequence;
        }
    }
}
