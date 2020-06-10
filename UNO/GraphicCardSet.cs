using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UNO
{
    class GraphicCardSet:CardSet
    {
        public Panel Panel { get; set; }

        public GraphicCardSet(Panel panel) : base()
        {
            Panel = panel;
        }

        public GraphicCardSet(Panel panel, CardSetType cardSetType) : this(panel)
        {
            if (cardSetType == CardSetType.Empty) return;

            foreach (var figure in Enum.GetValues(typeof(CardFigure)))
            {
                foreach (var color in Enum.GetValues(typeof(CardColor)))
                {
                    if ((CardFigure)figure == CardFigure.Zero)
                    {
                        Cards.Add(new GraphicValueCard((CardColor)color, CardFigure.Zero));
                    }
                    else if ((CardFigure)figure != CardFigure.Zero)
                    {
                        for(int i = 1; i <= 2; i++)
                        {
                            Cards.Add(new GraphicValueCard((CardColor)color, (CardFigure)figure));
                        }
                    }
                }
            }

            foreach (var function in Enum.GetValues(typeof(CardFunction)))
            {
                for(int i = 1; i<=4; i++)
                {
                    Cards.Add(new GraphicFunctionCard((CardFunction)function));
                }
            }
            
            foreach (var colorFunction in Enum.GetValues(typeof(CardColorFunction)))
            {
                foreach (var color in Enum.GetValues(typeof(CardColor)))
                {
                    for(int i = 1; i<=2; i++)
                    {
                        Cards.Add(new GraphicColorFunctionCard((CardColor)color, (CardColorFunction)colorFunction));
                    }
                }
            }
        }

        public override void Show()
        {
            Panel.Controls.Clear();
            for (int k = 0; k < Cards.Count; k++)
            {
                    IGraphics card = (IGraphics)Cards[k];
                    PictureBox pb = card.Pb;
                    Panel.Controls.Add(pb);
                    pb.BringToFront();
                    pb.Size = new Size(Panel.Height * pb.Image.Width / pb.Image.Height, Panel.Height);
                    pb.Location = new Point(k * (Panel.Width - pb.Width) / Cards.Count, 0);
                    pb.TabIndex = k;
                    pb.TabStop = false;
                    card.Show();
            }
        }
    }
}

