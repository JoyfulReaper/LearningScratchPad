using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WINFORMSTESTA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var t = e.Graphics;
            t.FillEllipse(Brushes.Red, new Rectangle(5, 5, 10, 10));

            t.FillCircle(Brushes.Yellow, 48, 48, 45);
            t.FillCircle(Brushes.Black, 30, 35, 10);
            t.FillCircle(Brushes.Black, 65, 35, 10);
            t.FillCircle(Brushes.Black, 47, 55, 8);
        }
    }
}
