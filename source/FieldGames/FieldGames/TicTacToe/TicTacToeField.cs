using FieldGames.Core;
using System;

namespace FieldGames.TicTacToe
{
    public class TicTacToeField : Field<Symbol>
    {
        public TicTacToeField() : this(3, 3) { }
        protected TicTacToeField(int width, int height) : base(width, height)
        {
        }
    }
}
