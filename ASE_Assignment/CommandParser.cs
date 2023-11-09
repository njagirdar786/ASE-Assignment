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
                try
                {
                    ParseIndividualCommand(c, canvas, pen);
                }
                catch (GPLexceptions.InvalidCommandException ex)
                { 
                    Console.WriteLine("Command Error: " + ex.Message);
                }
                catch (GPLexceptions.InvalidParameterException ex)
                {
                    Console.WriteLine("Parameter Error: " + ex.Message);
                }
            }
        }

        private void ParseIndividualCommand(string command, Canvass canvas, Pen pen)
        {
            string[] commandParts = command.Split(' ');

            if(commandParts.Length == 0 )
            {
                throw new GPLexceptions.InvalidCommandException("command is empty");
            }

            if (commandParts[0] == "circle")
            {
                if (commandParts.Length != 2)
                {
                    throw new GPLexceptions.InvalidCommandException("invalid number of paramters for circle command");
                }

                if (!Int32.TryParse(commandParts[1], out int radius) || radius <= 0) 
                {
                    throw new GPLexceptions.InvalidParameterException("invalid parameters for circle command, must enter a positive integer");
                }

                Shape circle = new Circle(pen.Color, 10, 10, radius);
                canvas.DrawShape(circle, fill);
            }
            else if (commandParts[0] == "rectangle")
            {

                if (commandParts.Length != 3)
                {
                    throw new GPLexceptions.InvalidCommandException("invalid number of paramters for rectangle command");
                }

                if (!Int32.TryParse(commandParts[1], out int width) || !Int32.TryParse(commandParts[2], out int height) || width <= 0 || height <= 0)
                {
                    throw new GPLexceptions.InvalidParameterException("invalid parameters for rectangle command, must enter positive integers");
                }

                Shape rectangle = new Rectangle(pen.Color, 10, 10, width, height);
                canvas.DrawShape(rectangle, fill);
            }
            else if (commandParts[0] == "triangle")
            {
                int s1 = Int32.Parse(commandParts[1]);
                int s2 = Int32.Parse(commandParts[2]);
                int s3 = Int32.Parse(commandParts[3]);
                Shape triangle = new Triangle(pen.Color, 10, 10, s1, s2, s3);
                canvas.DrawShape(triangle, fill);
            }
            else if (commandParts[0] == "moveTo")
            {

                if (commandParts.Length != 3)
                {
                    throw new GPLexceptions.InvalidCommandException("invalid number of paramters for moveTo command");
                }

                if (!Int32.TryParse(commandParts[1], out int x) || !Int32.TryParse(commandParts[2], out int y) || x <= 0 || y <= 0)
                {
                    throw new GPLexceptions.InvalidParameterException("invalid parameters for moveTo command, must enter positive integers");
                }

                canvas.MoveTo(x, y);
            }
            else if (commandParts[0] == "drawLine")
            {

                if (commandParts.Length != 3)
                {
                    throw new GPLexceptions.InvalidCommandException("invalid number of paramters for drawLine command");
                }

                if (!Int32.TryParse(commandParts[1], out int x) || !Int32.TryParse(commandParts[2], out int y) || x <= 0 || y <= 0)
                {
                    throw new GPLexceptions.InvalidParameterException("invalid parameters for drawLine command, must enter positive integers");
                }

                canvas.DrawLine(pen, x, y);
            }
            else if (commandParts[0] == "clear")
            {
                if (commandParts.Length != 1)
                {
                    throw new GPLexceptions.InvalidCommandException("clear command has no parameters");
                }

                canvas.Clear();
            }
            else if (commandParts[0] == "reset")
            {
                if (commandParts.Length != 1)
                {
                    throw new GPLexceptions.InvalidCommandException("reset command has no parameters");
                }

                canvas.Reset();
            }
            else if (commandParts[0] == "pen")
            {

                if (commandParts.Length != 2)
                {
                    throw new GPLexceptions.InvalidCommandException("invalid number of paramters for pen command");
                }

                if(commandParts[1] != "red" || commandParts[1] != "green" || commandParts[1] != "blue" || commandParts[1] != "black")
                {
                    throw new GPLexceptions.InvalidParameterException("invalid parameter for pen command: choose from red/green/blue/black");
                }

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
            else if (commandParts[0] == "fill")
            {
                if (commandParts.Length != 2)
                {
                    throw new GPLexceptions.InvalidCommandException("invalid number of paramters for fill command");
                }

                if (commandParts[1] != "on" || commandParts[1] != "off")
                {
                    throw new GPLexceptions.InvalidParameterException("invalid parameter for fill command: choose from on/off");
                }

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
            else
            {
                throw new GPLexceptions.InvalidCommandException("Unknown command: " + commandParts[0]);
            }
           
        }
    }
}
