using System;
using System.Collections.Generic;

namespace FieldGames.Core
{
    public interface IGame<T>
    {
        int MaxPlayers { get; }
        ICollection<IPlayer> Players { get; }
        IField<T> Field { get; }
        void Act(IPlayer player, Action action);
    }
}
