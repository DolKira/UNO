using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using UNO.Cards;

namespace UNO
{
    class GraphicCardSet:CardSet
    {
        public Panel Panel { get; set; }

        public GraphicCardSet(Panel panel) : base()
        {
            Panel = panel;
        }

        public GraphicCardSet(Panel panel, int count) : this(panel)
        {
            foreach (var figure in Enum.GetValues(typeof(CardFigure)))
            {
                foreach (var color in Enum.GetValues(typeof(CardColor)))
                {
                    Cards.Add(new ValueCard((CardColor)color, (CardFigure)figure));
                }
            }
            
            //foreach (var function in Enum.GetValues(typeof(ColorFunctionCard)))
            //{
            //    foreach (var color in Enum.GetValues(typeof(ColorFunctionCard)))
            //    {
            //        Cards.Add(new ColorFunctionCard((CardColor)color, (CardFunction)function));
            //    }
            //}

            //foreach (var function in Enum.GetValues(typeof(CardFunction)))
            //{
            //    Cards.Add(new FunctionCard((CardFunction)function));
            //}

            if (count < Count)
                Cards.RemoveRange(0, Count - count);
        }

        public override void Show()
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                GraphicCard graphicCard = (GraphicCard)Cards[i];
                PictureBox pb = graphicCard.Pb;
                Panel.Controls.Add(pb);
                pb.BringToFront();
                pb.Size = new Size(Panel.Height * pb.Image.Width / pb.Image.Height, Panel.Height);
                pb.Location = new Point(i * (Panel.Width - pb.Width) / Cards.Count, 0);
                pb.TabIndex = i;
                pb.TabStop = false;
                graphicCard.Show();
            }
        }
    }
}
