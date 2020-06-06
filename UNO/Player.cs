using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO
{
    class Player
    {
        public string Name { get; set; }
        public CardSet PlayerCards { get; set; }
        public Player(string name) : this()
        {
            Name = name;
        }
        public Player()
        {
            PlayerCards = new CardSet();
        }

        public Player(string name, CardSet cardset) : this(name)
        {
            PlayerCards = cardset;
        }
    }
}
