using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_Assignment
{
    public partial class Form1 : Form
    {
        Bitmap myBitmap;

        public Form1()
        {
            InitializeComponent();

            myBitmap = new Bitmap(315, 393);

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {

            Graphics g = Graphics.FromImage(myBitmap);

            Shape circle1 = new Circle(Color.Red, 10, 10, 100);

            circle1.draw(g);

            pictureBox1.Image = myBitmap;

        }
    }
}
