using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNO.Cards;

namespace UNO
{
    class ColorFunctionCard:Card,IColor,IFunctional
    {
        public ColorFunctionCard(CardColor color, CardFunction function)
        {
            Color = color;
            Function = function;
        }

        public CardColor Color { get; set; }
        public CardFunction Function { get; set; }

        public override string ToString()
        {
            return String.Format("{0}_{1}", Color, Function);
        }

        public void DoFunction(Game game)
        {
            switch (Function)
            {
                case CardFunction.Skip:
                    game.IsSkip = true;
                    break;
                case CardFunction.Reverse:
                    game.Reverse = !game.Reverse;
                    break;
                case CardFunction.AddTwo:
                    game.NextMover.PlayerCards.Add(game.Deck.Deal(2));
                    break;
                default:
                    break;
            }
            game.currentColor = Color;
        }

    }
}
