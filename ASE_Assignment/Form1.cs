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
        Pen pen;
        String command;
        Canvass canvas;

        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black, 2);
            canvas = new Canvass(pen,313, 393);
            

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            command = singleTextBox.Text;
            CommandParser cp = new CommandParser(command, canvas, pen);
            Bitmap myBitmap = canvas.GetBitmap();
            pictureBox1.Image = myBitmap;
            singleTextBox.Clear();
        }
    }
}
