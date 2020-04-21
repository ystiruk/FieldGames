namespace FieldGames.Core
{
    public interface IField<T>
    {
        int Width { get; }
        int Height { get; }
        T this[int row, int column] { get; set; }
    }
}
