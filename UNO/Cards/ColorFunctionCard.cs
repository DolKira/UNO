using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO
{
    class ColorFunctionCard:Card,IColor,IColorFunction
    {
        public ColorFunctionCard(CardColor color, CardColorFunction colorFunction)
        {
            Color = color;
            ColorFunction = colorFunction;
        }

        public CardColor Color { get; set; }
        public CardColorFunction ColorFunction { get; set; }

        public override string ToString()
        {
            return String.Format("{0}_{1}", Color, ColorFunction);
        }

        public void DoColorFunction(Game game)
        {
            switch (ColorFunction)
            {
                case CardColorFunction.Skip:
                    game.IsSkip = true;
                    break;
                case CardColorFunction.Reverse:
                    game.Reverse = !game.Reverse;
                    break;
                case CardColorFunction.AddTwo:
                    game.NextMover.PlayerCards.Add(game.Deck.Pull(2));
                    game.IsSkip = true;
                    break;
                default:
                    break;
            }
        }

        public override CardColor GetColor(Game game)
        {
            return Color;
        }
    }
}
