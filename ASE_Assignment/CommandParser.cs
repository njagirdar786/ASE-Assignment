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
        public CommandParser(string command, Canvass canvas, Pen pen)
        {

            string[] commandParts = command.Split(' ');

            if (commandParts[0] == "circle")
            {
                int radius = Int32.Parse(commandParts[1]);
                Shape circle = new Circle(pen.Color, 10, 10, radius);
                canvas.DrawShape(circle);
            }
            else if (commandParts[0] == "rectangle")
            {
                int width = Int32.Parse(commandParts[1]);
                int height = Int32.Parse(commandParts[2]);
                Shape rectangle = new Rectangle(pen.Color, 10, 10, width, height);
                canvas.DrawShape(rectangle);
            }
            else if (commandParts[0] == "triangle")
            {
                int s1 = Int32.Parse(commandParts[1]);
                int s2 = Int32.Parse(commandParts[2]);
                int s3 = Int32.Parse(commandParts[3]);
                Shape triangle = new Triangle(pen.Color, 10, 10, s1, s2, s3);
                canvas.DrawShape(triangle);
            }
            else if (commandParts[0] == "moveTo")
            {
                int x = Int32.Parse(commandParts[1]);
                int y = Int32.Parse(commandParts[2]);
                canvas.MoveTo(x, y);
            }
            else if (commandParts[0] == "drawLine")
            {
                int x = Int32.Parse(commandParts[1]);
                int y = Int32.Parse(commandParts[2]);
                canvas.DrawLine(pen, x, y);
            }
            else if (commandParts[0] == "clear")
            {
                canvas.Clear();
            }
            else if (commandParts[0] == "reset")
            {
                canvas.Reset();
            }
        }
    }
}
