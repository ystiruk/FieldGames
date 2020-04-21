namespace FieldGames.WordByWord
{
    public interface IWordProvider
    {
        bool Contains(string word);
        bool StartsWith(string prefix);
    }
}
