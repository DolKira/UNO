using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UNO
{
    interface IGraphics
    {
        PictureBox Pb { get; set; }
        bool Opened { get; set; }

        void Show();
    }
}
