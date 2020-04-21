namespace FieldGames.Core
{
    public interface IGame<T>
    {
        IField<T> Field { get; }
        void AddPlayer(IPlayer player);
    }
}
