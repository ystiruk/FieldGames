using FieldGames.Core;
using System;
using System.Linq;

namespace FieldGames.TicTacToe
{
    public abstract class TPlayer : IPlayer
    {
        public event Action<TSymbol, int, int> SetSymbol;

        protected TGame _game;

        public string Name { get; }
        public TSymbol Symbol { get; }

        public TPlayer(string name, TSymbol symbol)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));
            if (symbol == TSymbol.Empty) throw new ArgumentException(nameof(symbol));

            Name = name;
            Symbol = symbol;
        }

        public abstract void Act();

        public void SetGame(object game)
        {
            _game = (TGame)game;
        }

        protected void OnSetSymbol(TSymbol symbol, int row, int column)
        {
            SetSymbol?.Invoke(symbol, row, column);
        }
    }

    public class TConsolePlayer : TPlayer
    {
        public TConsolePlayer(string name, TSymbol symbol) : base(name, symbol) { }

        public override void Act()
        {
            Console.Write($"{Name}`s turn: ");
            int[] coords = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            OnSetSymbol(Symbol, coords[0], coords[1]);
        }
    }

    public class TComputerPlayer : TPlayer
    {
        private static Random _rand = new Random();

        public TComputerPlayer(TSymbol symbol) : this(Environment.MachineName, symbol) { }
        protected TComputerPlayer(string name, TSymbol symbol) : base(name, symbol) { }

        public override void Act()
        {
            Console.Write($"{Name}`s turn: ");
            int[] coords = { _rand.Next(0, 3), _rand.Next(0, 3) };
            Console.WriteLine($"{coords[0]} {coords[1]}");

            OnSetSymbol(Symbol, coords[0], coords[1]);
        }
    }
}
