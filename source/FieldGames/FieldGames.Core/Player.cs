using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldGames.Core
{
    public class Player : IPlayer
    {
        public string Name { get; }
        
        public Player(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));

            Name = name;
        }
    }
}
