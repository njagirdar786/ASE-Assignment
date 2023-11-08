using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    internal class CommandParser
    {
        bool fill = false;
        public CommandParser(string command, Canvass canvas, Pen pen)
        {
            string[] commands = command.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string c in commands)
            {
                ParseIndividualCommand(c, canvas, pen);
            }
        }

        private void ParseIndividualCommand(string command, Canvass canvas, Pen pen)
        {
            string[] commandParts = command.Split(' ');


            if (commandParts[0] == "circle" && commandParts.Length == 2)
            {
                int radius = Int32.Parse(commandParts[1]);
                Shape circle = new Circle(pen.Color, 10, 10, radius);
                canvas.DrawShape(circle, fill);
            }
            else if (commandParts[0] == "rectangle" && commandParts.Length == 3)
            {
                int width = Int32.Parse(commandParts[1]);
                int height = Int32.Parse(commandParts[2]);
                Shape rectangle = new Rectangle(pen.Color, 10, 10, width, height);
                canvas.DrawShape(rectangle, fill);
            }
            else if (commandParts[0] == "triangle" && commandParts.Length == 4)
            {
                int s1 = Int32.Parse(commandParts[1]);
                int s2 = Int32.Parse(commandParts[2]);
                int s3 = Int32.Parse(commandParts[3]);
                Shape triangle = new Triangle(pen.Color, 10, 10, s1, s2, s3);
                canvas.DrawShape(triangle, fill);
            }
            else if (commandParts[0] == "moveTo" && commandParts.Length == 3)
            {
                int x = Int32.Parse(commandParts[1]);
                int y = Int32.Parse(commandParts[2]);
                canvas.MoveTo(x, y);
            }
            else if (commandParts[0] == "drawLine" && commandParts.Length == 3)
            {
                int x = Int32.Parse(commandParts[1]);
                int y = Int32.Parse(commandParts[2]);
                canvas.DrawLine(pen, x, y);
            }
            else if (commandParts[0] == "clear" && commandParts.Length == 1)
            {
                canvas.Clear();
            }
            else if (commandParts[0] == "reset" && commandParts.Length == 1)
            {
                canvas.Reset();
            }
            else if (commandParts[0] == "pen" && commandParts.Length == 2)
            {
                if (commandParts[1] == "red")
                {
                    pen.Color = Color.Red;
                }
                if (commandParts[1] == "green")
                {
                    pen.Color = Color.Green;
                }
                if (commandParts[1] == "blue")
                {
                    pen.Color = Color.Blue;
                }
                if (commandParts[1] == "black")
                {
                    pen.Color = Color.Black;
                }
            }
            else if (commandParts[0] == "fill" && commandParts.Length == 2)
            {
                if (commandParts[1] == "on")
                {
                    fill = true;
                    Console.WriteLine("fill on");
                } 
                else if (commandParts[1] == "off")
                {
                    fill = false;
                    Console.WriteLine("fill off");
                }
            }
           
        }
    }
}
