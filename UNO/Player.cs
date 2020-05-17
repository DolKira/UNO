using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO
{
    class Player
    {
        public int Position { get; set; }
        public string Name { get; set; }
        public CardSet PlayerCards { get; set; }
        public Player(string name)
        {
            Name = name;
        }
        public Player()
        {
            PlayerCards = new CardSet();
        }
    }
}
