using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace UNO
{
    class CardDesk
    {
        public Panel Panel { get; set; }
        public List<Card> Cards { get; set; }
        public CardDesk(Panel panel) : base()
        {
            Panel = panel;
        }
        public CardDesk(CardColor color, CardFigure figure, object sender, PaintEventArgs e, PictureBox picture)
        {
            switch (color)
            {
                case CardColor.Green:
                    switch (figure)
                    {
                        case CardFigure.Zero:
                            picture.Image = new Bitmap("D:\\UNO cards\\Green_0.png");
                            break;
                        case CardFigure.One:
                            picture.Image = new Bitmap("D:\\UNO cards\\Green_1.png");
                            picture.Image = new Bitmap("D:\\UNO cards\\Red_1.png");
                            break;
                        case CardFigure.Two:
                            picture.Image = new Bitmap("D:\\UNO cards\\Red_2.png");
                            picture.Image = new Bitmap("D:\\UNO cards\\Red_2.png");
                            break;
                        case CardFigure.Three:
                            picture.Image = new Bitmap("D:\\UNO cards\\Red_3.png");
                            picture.Image = new Bitmap("D:\\UNO cards\\Red_3.png");
                            break;
                        case CardFigure.Four:
                            picture.Image = new Bitmap("D:\\UNO cards\\Red_4.png");
                            picture.Image = new Bitmap("D:\\UNO cards\\Red_4.png");
                            break;
                        case CardFigure.Five:
                            picture.Image = new Bitmap("D:\\UNO cards\\Red_5.png");
                            picture.Image = new Bitmap("D:\\UNO cards\\Red_5.png");
                            break;
                        case CardFigure.Six:
                            picture.Image = new Bitmap("D:\\UNO cards\\Red_6.png");
                            picture.Image = new Bitmap("D:\\UNO cards\\Red_6.png");
                            break;
                        case CardFigure.Seven:
                            picture.Image = new Bitmap("D:\\UNO cards\\Red_7.png");
                            picture.Image = new Bitmap("D:\\UNO cards\\Red_7.png");
                            break;
                        case CardFigure.Eight:
                            picture.Image = new Bitmap("D:\\UNO cards\\Red_8.png");
                            picture.Image = new Bitmap("D:\\UNO cards\\Red_8.png");
                            break;
                        case CardFigure.Nine:
                            picture.Image = new Bitmap("D:\\UNO cards\\Red_9.png");
                            picture.Image = new Bitmap("D:\\UNO cards\\Red_9.png");
                            break;
                    }
                    break;
            }
            
        }
    }
}
