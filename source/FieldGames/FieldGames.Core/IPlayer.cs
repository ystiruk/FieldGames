namespace FieldGames.Core
{
    public interface IPlayer
    {
        string Name { get; }
        void SetGame(object game);
    }
}
