using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UNO
{
    class GraphicColorFunctionCard:ColorFunctionCard, IGraphics
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
        public readonly string imageShirtPath = Application.StartupPath + @"\Cards\Back.png";
        public readonly string fileName;

        public GraphicColorFunctionCard(CardColor colorCard, CardColorFunction colorfunctionCard, PictureBox pb, bool opened = false) : base(colorCard, colorfunctionCard)
        {
            Pb = pb;
            Pb.SizeMode = PictureBoxSizeMode.Zoom;
            Pb.Visible = false;
            fileName = Application.StartupPath + @"\Cards\" + this.ToString() + ".png";
            Opened = opened;
        }
        public GraphicColorFunctionCard(CardColor colorCard, CardColorFunction colorfunctionCard, bool opened = true) : this(colorCard, colorfunctionCard, new PictureBox(), opened) { }
         
        public override void Show()
        {
            Pb.Visible = true;
        }

        public override string ToString()
        {
            return String.Format($"{Color}_{ColorFunction}");
        }
    }
}
