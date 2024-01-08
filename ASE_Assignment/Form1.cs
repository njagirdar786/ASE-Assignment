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
    /// <summary>
    /// The main form of the application.
    /// </summary>
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

        /// <summary>
        /// Event handler for submit button click.
        /// </summary>
        private void submitBtn_Click(object sender, EventArgs e)
        {
            // Determine the textbox to execute commands from based on the one the user chooses to type in.
            if(singleTextBox.Text == "" && multiTextBox.Text != "")
            {
                command = multiTextBox.Text;
            }
            else if(singleTextBox.Text != "" && multiTextBox.Text == "")
            {
                command = singleTextBox.Text;
            }

            
                // Parse and execute the command using CommandParser
                CommandParser cp = new CommandParser(command, canvas, pen);
                Bitmap myBitmap = canvas.GetBitmap();
                pictureBox1.Image = myBitmap;
                singleTextBox.Clear();
                //Exception handling
                List<String> errors = cp.GetErrors();
                if (errors.Count > 0)
                {
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
                    MessageBox.Show("::::Errors in the program:::: " + Environment.NewLine + string.Join(Environment.NewLine, errors));
                }

        }
        /// <summary>
        /// Event Handler for save button click
        /// </summary>
        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                string filePath = sfd.FileName;
                string[] commandsToSave =  command.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                System.IO.File.WriteAllLines(filePath, commandsToSave);
                MessageBox.Show("Commands saved successfully");
            }

        }
        /// <summary>
        /// Event Handler for save button click
        /// </summary>
        private void openBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                multiTextBox.Clear();
                string filePath = ofd.FileName;
                string[] commandsToOpen = System.IO.File.ReadAllLines(filePath);

                foreach (string c in commandsToOpen)
                {
                    //populate multiTextBox with the commands from the opened file. appends a new line to the end of every command
                    multiTextBox.Text += c + Environment.NewLine;
                }
            }

        }

        private void runBoth_Click(object sender, EventArgs e)
        {
            Console.WriteLine(multiTextBox2.Text);
        }
    }
}
