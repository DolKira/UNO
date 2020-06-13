using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO
{
    class FunctionCard: Card, IFunctional
    {
        public FunctionCard(CardFunction function)
        {
            Function = function;
        }

        public CardFunction Function { get; set; }

        public override string ToString()
        {
            return String.Format("Black_{0}", Function);
        }

        public void DoFunction(Game game)
        {
            switch (Function)
            {
                case CardFunction.AddFour:
                    game.NextMover.PlayerCards.Add(game.Deck.Pull(4));
                    break;
                case CardFunction.ChangeColor:
                    break;
            }
        }

        public override CardColor GetColor(Game game)
        {
            return game.ColorRequest();
        }
    }
}
