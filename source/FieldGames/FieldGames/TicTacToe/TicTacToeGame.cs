using FieldGames.Core;
using System;
using System.Collections.Generic;

namespace FieldGames.TicTacToe
{
    public class TicTacToeGame : IGame<Symbol>
    {
        private ICollection<IPlayer> _players;

        public IField<Symbol> Field { get; }

        public TicTacToeGame()
        {
            Field = new TicTacToeField();
            _players = new List<IPlayer>();
        }

        public void AddPlayer(IPlayer player)
        {
            _players.Add(player);
            player.SetGame(this);
        }

        static char[] map = { ' ', 'x', 'o' };

        public void Render()
        {
            Console.WriteLine("- - - - -");
            for (int i = 0; i < Field.Height; i++)
            {
                for (int j = 0; j < Field.Width; j++)
                {
                    Console.Write($"{map[(int)Field[i, j]]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("- - - - -");
        }
    }
}
