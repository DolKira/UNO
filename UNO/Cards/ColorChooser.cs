using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNO.Cards
{
    public partial class ColorChooser : Form
    {
        public string SelectedColor;
        public ColorChooser()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }
        
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 
            SelectedColor = comboBox1.SelectedItem.ToString();
            MessageBox.Show(SelectedColor);
            Form1 fr1 = new Form1();
            fr1.Show();
            Hide();
        }
    }
}
