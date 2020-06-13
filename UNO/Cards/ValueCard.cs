using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO
{
    class ValueCard: Card, IColor, IFigure
    {
        public CardFigure Figure { get; set; }
        public CardColor Color { get; set; }
        public ValueCard(CardColor color, CardFigure figure)
        {
            Color = color;
            Figure = figure;
        }
        public override string ToString()
        {
            return String.Format("{0}_{1}", Color, Figure);
        }

        public override CardColor GetColor(Game game)
        {
            return Color;
        }
    }
}
