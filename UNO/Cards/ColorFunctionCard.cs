using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO
{
    class ColorFunctionCard:FunctionCard
    {
        public ColorFunctionCard(CardColor color, CardFunction function):base(function)
        {
            Color = color;
        }

        public CardColor Color { get; set; }

        public override string ToString()
        {
            return String.Format("{0}_{1}", Color, Function);
        }

        public override void DoFunction(Game game)
        {
            switch (Function)
            {
                case CardFunction.Skip:
                    Ac

                    break;
                case CardFunction.Reverse:
                    break;
                case CardFunction.AddTwo:
                    break;
                default:
                    break;
            }
            game.currentColor = Color;
        }

    }
}
