using FieldGames.Core;
using System;

namespace FieldGames.TicTacToe
{
    public class TField : Field<TSymbol>
    {
        public TField(int width, int height) : base(width, height) { }
    }
}
