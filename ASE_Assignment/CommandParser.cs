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

            if (commandParts[0] == "circle" && int.TryParse(commandParts[1], out int radius))
            {
                Shape circle = new Circle(pen.Color, 10, 10, radius);
                canvas.DrawShape(circle);
            }

        }
    }
}
