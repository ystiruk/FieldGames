using System;

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

        public int Width => field.GetLength(1);
        public int Height => field.GetLength(0);

        protected Field(int width, int height)
        {
            if (width <= 0) throw new ArgumentException(nameof(width));
            if (height <= 0) throw new ArgumentException(nameof(height));

            field = new T[height, width];
        }
    }
}
