using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UNO
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private CardColor color;

        public CardColor IColor
        {
            get { return color; }
        }

        private void RedButton_Click(object sender, EventArgs e)
        {
            color = CardColor.Red;
            //Form1 fr1 = new Form1();
            //From1.Show();
            Hide();
        }

        private void BlueButton_Click(object sender, EventArgs e)
        {
            color = CardColor.Blue;
            Form1 fr1 = new Form1();
            fr1.Show();
            Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void GreenButton_Click(object sender, EventArgs e)
        {
            color = CardColor.Green;
            Form1 fr1 = new Form1();
            fr1.Show();
            Hide();
        }

        private void YellowButton_Click(object sender, EventArgs e)
        {
            color = CardColor.Yellow;
            Form1 fr1 = new Form1();
            fr1.Show();
            Hide();
        }
    }
}
