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
                for (int k = 0; k < Cards.Count; k++)
                {
                    if(Cards[k] is GraphicValueCard)
                    {
                        GraphicValueCard graphicValueCard = (GraphicValueCard)Cards[k];
                        PictureBox pb = graphicValueCard.Pb;
                        Panel.Controls.Add(pb);
                        pb.BringToFront();
                        pb.Size = new Size(Panel.Height * pb.Image.Width / pb.Image.Height, Panel.Height);
                        pb.Location = new Point(k * (Panel.Width - pb.Width) / Cards.Count, 0);
                        pb.TabIndex = k;
                        pb.TabStop = false;
                        graphicValueCard.Show();
                    }
                }

            for (int n = 0; n < Cards.Count; n++)
                {
                    if (Cards[n] is GraphicFunctionCard)
                    {
                        GraphicFunctionCard graphicFunctionCard = (GraphicFunctionCard)Cards[n];
                        IGraphics graphics = graphicFunctionCard;
                        Panel.Controls.Add(graphics.Pb);
                        graphics.Pb.BringToFront();
                        graphics.Pb.Size = new Size(Panel.Height * graphics.Pb.Image.Width / graphics.Pb.Image.Height, Panel.Height);
                        graphics.Pb.Location = new Point(n * (Panel.Width - graphics.Pb.Width) / Cards.Count, 0);
                        graphics.Pb.TabIndex = n;
                        graphics.Pb.TabStop = false;
                        graphicFunctionCard.Show();
                    }
                }
       
           
                for (int m = 0; m < Cards.Count; m++)
                {
                    if(Cards[m] is GraphicColorFunctionCard)
                    {
                        GraphicColorFunctionCard graphicColorFunctionCard = (GraphicColorFunctionCard)Cards[m];
                        PictureBox pb = graphicColorFunctionCard.Pb;
                        Panel.Controls.Add(pb);
                        pb.BringToFront();
                        pb.Size = new Size(Panel.Height * pb.Image.Width / pb.Image.Height, Panel.Height);
                        pb.Location = new Point(m * (Panel.Width - pb.Width) / Cards.Count, 0);
                        pb.TabIndex = m;
                        pb.TabStop = false;
                        graphicColorFunctionCard.Show();
                    }   
                }
        }
    }
}

