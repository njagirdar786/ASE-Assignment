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
        }
    }
}
