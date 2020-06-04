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
                        Cards.Add(new GraphicValueCard((CardColor)color, (CardFigure)figure));
                        Cards.Add(new GraphicValueCard((CardColor)color, (CardFigure)figure));
                    }
                }
            }

            foreach (var function in Enum.GetValues(typeof(CardFunction)))
            {
                Cards.Add(new GraphicFunctionCard((CardFunction)function));
                Cards.Add(new GraphicFunctionCard((CardFunction)function));
            }
            
            foreach (var colorFunction in Enum.GetValues(typeof(CardColorFunction)))
            {
                foreach (var color in Enum.GetValues(typeof(CardColor)))
                {
                       Cards.Add(new GraphicColorFunctionCard((CardColor)color, (CardColorFunction)colorFunction));
                       Cards.Add(new GraphicColorFunctionCard((CardColor)color, (CardColorFunction)colorFunction));
                }
            }
        }

        public override void Show()
        {
            for(int i = 0; i < 108; i++)
            {
                for (int n = 0; i < 2; i++)
                {
                    GraphicFunctionCard graphicFunctionCard = (GraphicFunctionCard)Cards[n];
                    PictureBox pb = graphicFunctionCard.Pb;
                    Panel.Controls.Add(pb);
                    pb.BringToFront();
                    pb.Size = new Size(Panel.Height * pb.Image.Width / pb.Image.Height, Panel.Height);
                    pb.Location = new Point(i * (Panel.Width - pb.Width) / Cards.Count, 0);
                    pb.TabIndex = i;
                    pb.TabStop = false;
                    graphicFunctionCard.Show();
                }
                for (int m = 9; i < 33; i++)
                {
                    GraphicColorFunctionCard graphicColorFunctionCard = (GraphicColorFunctionCard)Cards[m];
                    PictureBox pb = graphicColorFunctionCard.Pb;
                    Panel.Controls.Add(pb);
                    pb.BringToFront();
                    pb.Size = new Size(Panel.Height * pb.Image.Width / pb.Image.Height, Panel.Height);
                    pb.Location = new Point(i * (Panel.Width - pb.Width) / Cards.Count, 0);
                    pb.TabIndex = i;
                    pb.TabStop = false;
                    graphicColorFunctionCard.Show();
                }
                for (int k = 34; i < 108; i++)
                {
                    GraphicValueCard graphicValueCard = (GraphicValueCard)Cards[k];
                    PictureBox pb = graphicValueCard.Pb;
                    Panel.Controls.Add(pb);
                    pb.BringToFront();
                    pb.Size = new Size(Panel.Height * pb.Image.Width / pb.Image.Height, Panel.Height);
                    pb.Location = new Point(i * (Panel.Width - pb.Width) / Cards.Count, 0);
                    pb.TabIndex = i;
                    pb.TabStop = false;
                    graphicValueCard.Show();
                }
            }
        }
    }
}
