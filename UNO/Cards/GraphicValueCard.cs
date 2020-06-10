using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace UNO
{
    class GraphicValueCard:ValueCard, IGraphics
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
                Pb.Image = opened ? Image.FromFile(fileName) : Image.FromFile(imageShirtPath);
            }
        }

        private bool opened;
        private readonly string imageShirtPath = Application.StartupPath + @"\Cards\Back.png";
        private readonly string fileName;

        public GraphicValueCard(CardColor colorCard, CardFigure figureCard, PictureBox pb, bool opened = true) : base(colorCard, figureCard)
        {
            Pb = pb;
            Pb.SizeMode = PictureBoxSizeMode.Zoom;
            Pb.Visible = false;
            fileName = Application.StartupPath + @"\cards\" + this.ToString() + ".png";
            Opened = opened;
        }
        public GraphicValueCard(CardColor colorCard, CardFigure figureCard, bool opened = false) : this(colorCard, figureCard, new PictureBox(), opened) { }

        public override void Show()
        {
            Pb.Visible = true;
        }

        public override string ToString()
        {
            return String.Format($"{Color}_{Figure}");
        }
    }
}
