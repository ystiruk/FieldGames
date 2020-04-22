using FieldGames.Core;
using System;
using System.Collections.Generic;
using static FieldGames.Core.ExtensionMethods;

namespace FieldGames.TicTacToe
{
    public class TGame
    {
        private IList<TPlayer> _players;
        private TField _field;
        private IEnumerator<TPlayer> _playersOrder;
        public TPlayer NextPlayer
        {
            get
            {
                _playersOrder.MoveNext();
                return _playersOrder.Current;
            }
        }

        public TGame()
        {
            _players = new List<TPlayer>();
            _playersOrder = _players.Circle().GetEnumerator();

            _field = new TField(3, 3);
        }

        public bool IsEnd => false;

        public void AddPlayers(string playerName1, string playerName2)
        {
            TPlayer player1 = new TConsolePlayer(playerName1, TSymbol.Cross);
            
            player1.SetGame(this);
            player1.SetSymbol += OnPlayerSetSymbol;
            _players.Add(player1);

            TPlayer player2 = new TComputerPlayer(TSymbol.Nought);
            player2.SetGame(this);
            player2.SetSymbol += OnPlayerSetSymbol;
            _players.Add(player2);
        }

        public void OnPlayerSetSymbol(TSymbol symbol, int row, int column)
        {
            _field[row, column] = symbol;
        }

        static char[] map = { ' ', 'x', 'o' };
        public void Render()
        {
            Console.WriteLine("- - -");
            for (int i = 0; i < _field.Height; i++)
            {
                for (int j = 0; j < _field.Width; j++)
                {
                    Console.Write($"{map[(int)_field[i, j]]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("- - -");
        }
    }
}
