using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace UNO
{
    class GraphicCard:Card
    {
        public PictureBox Pb { get; set; }
        public bool Opened
        {
            get
            {
                return opened;
            }
            set
            {
                opened = value;
                Pb.Image = Opened ? Image.FromFile(fileName) : Image.FromFile(imageShirtPath);
            }
        }
        private bool opened;
        private readonly string imageShirtPath = Application.StartupPath + @"\Cards\Back.png";
        private readonly string fileName;

        public GraphicCard(CardFigure figure, CardColor color, PictureBox pb, bool opened = true):base(color, figure)
        {
            Pb = pb;
            Pb.SizeMode = PictureBoxSizeMode.Zoom;
            Pb.Visible = false;
            fileName = Application.StartupPath + @"\Cards\" + this.ToString() + ".png";
            Opened = opened;
        }

        public GraphicCard(CardFigure figure, CardColor color) : this(figure, color, new PictureBox()) { }
        public override void Show()
        {
            Pb.Visible = true;
        }

        public override string ToString()
        {
            return String.Format(ToString() + ".png");
        }
    }
}
