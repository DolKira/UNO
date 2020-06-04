using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using UNO.Cards;
using System.IO;

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
                Pb.Image = !opened ? Image.FromFile(fileName) : Image.FromFile(imageShirtPath);
            }
        }

        private bool opened;
        public readonly string imageShirtPath = Application.StartupPath + @"\Cards\Back.png";
        public readonly string fileName;
        public override string ToString()
        {
            return String.Format($"Black_{Function}");
        }

        public GraphicFunctionCard(CardFunction functionCard, PictureBox pb, bool opened = true):base(functionCard)
        {
            Pb = pb;
            Pb.SizeMode = PictureBoxSizeMode.Zoom;
            Pb.Visible = true;
            fileName = Application.StartupPath + @"\cards\" + this.ToString() + ".png";
            Opened = opened;
        }
        public GraphicFunctionCard(CardFunction functionCard, bool opened = true) :this(functionCard, new PictureBox(),opened) { }

        public override void Show()
        {
            Pb.Visible = true;
        }
    }
}
