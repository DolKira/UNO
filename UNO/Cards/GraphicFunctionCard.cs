using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using UNO.Cards;

namespace UNO
{
    class GraphicFunctionCard:FunctionCard
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

        public GraphicFunctionCard(CardFunction functionCard, PictureBox pb, bool opened = true):base(functionCard)
        {
            Pb = pb;
            Pb.SizeMode = PictureBoxSizeMode.Zoom;
            Pb.Visible = false;
            fileName = Application.StartupPath + @"\images\" + this.ToString() + ".png";
            Opened = opened;
        }
        public GraphicFunctionCard(CardFunction functionCard, bool opened = true) :this(functionCard, new PictureBox(),opened) { }

        public override void Show()
        {
            Pb.Visible = true;
        }

        public override string ToString()
        {
            return String.Format($"Color_Figure");
        }
    }
}
