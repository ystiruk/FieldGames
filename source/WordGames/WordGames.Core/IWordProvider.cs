﻿namespace WordGames.Core
{
    public interface IWordProvider
    {
        bool Contains(string word);
        bool StartsWith(string prefix);
    }
}