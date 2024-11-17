using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_23520734
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //typing nonsense so that i look productive in the video cause 
        // i am stuck at this very moment now
        // send help

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tuoi;
            tuoi = Int32.Parse(textBox1.Text.Trim());

            string ketqua = "Bạn đã " + tuoi.ToString() + " tuổi rồi!";
            textBox2.Text = ketqua;
        }
    }
}
