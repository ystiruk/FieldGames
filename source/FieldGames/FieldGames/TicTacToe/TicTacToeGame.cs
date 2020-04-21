using FieldGames.Core;
using System;
using System.Collections.Generic;

namespace FieldGames.TicTacToe
{
    public class TicTacToeGame : IGame<Symbol>
    {
        public int MaxPlayers { get { return 2; } }

        public ICollection<IPlayer> Players => new List<IPlayer>();

        public IField<Symbol> Field => Field;

        public void Act(IPlayer player, Action action)
        {
            throw new NotImplementedException();
        }
    }
}
