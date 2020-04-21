using FieldGames.Core;
using System;

namespace FieldGames.TicTacToe
{
    public class Player : IPlayer
    {
        private TicTacToeGame _game;

        public string Name { get; }
        
        public Player(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));

            Name = name;
        }

        public void Set(Symbol symbol, int row, int column)
        {
            _game.Field[row, column] = symbol;
        }

        public void SetGame(object game)
        {
            _game = (TicTacToeGame)game;
        }
    }
}
