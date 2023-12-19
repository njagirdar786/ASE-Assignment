﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_Assignment
{
    /// <summary>
    /// Parses and executes commands
    /// </summary>
    public class CommandParser
    {
        bool fill = false;

        //Dictionary to store variables, key -> value pairs
        private Dictionary<string, int> Variables = new Dictionary<string, int>();

        // Test method for checking if fill is true or false
        public bool isFilled()
        {
            return fill;
        }

        /// <summary>
        /// Initialise new instance of CommandParser, goes through command line by line and feeds it to ParseIndividualCommand.
        /// </summary>
        /// <param name="command">A string containing the commands entered by the user.</param>
        /// <param name="canvas">A canvas in which the results of the commands can be seen.</param>
        /// <param name="pen">The current drawing pen.</param>
        public CommandParser(string command, Canvass canvas, Pen pen)
        {
            string[] commands = command.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string c in commands)
            {
                    ParseIndividualCommand(c, canvas, pen);
            }
        }
        /// <summary>
        /// Parses and executes inidividual commands from CommandParser.
        /// </summary>
        /// <param name="command">An individual command.</param>
        /// <param name="canvas">A canvas in which the results of the commands can be seen</param>
        /// <param name="pen">The current drawing pen</param>
        /// <exception cref="GPLexceptions.InvalidCommandException">Exception if a command is not recognised or is entered incorrectly.</exception>
        /// <exception cref="GPLexceptions.InvalidParameterException">Exception if parameters for a command are invalid or the correct number of parameters have not been entered.</exception>
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
                if (commandParts.Length != 3)
                {
                    throw new GPLexceptions.InvalidCommandException("invalid number of paramters for triangle command");
                }

                if (!Int32.TryParse(commandParts[1], out int width) || !Int32.TryParse(commandParts[2], out int height) || width <= 0 || height <= 0)
                {
                    throw new GPLexceptions.InvalidParameterException("invalid parameters for triangle command, must enter positive integers");
                }
                
                Shape triangle = new Triangle(pen.Color, 10, 10, width, height);
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
                canvas.ClearShapeList();
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

                if(commandParts[1] != "red" && commandParts[1] != "green" && commandParts[1] != "blue" && commandParts[1] != "black")
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

                if (commandParts[1] != "on" && commandParts[1] != "off")
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
            else if (commandParts[0] == "var")
            {
                if (commandParts.Length != 4 || commandParts[2] != "=")
                {
                    throw new GPLexceptions.InvalidCommandException("invalid syntax for var command");
                }
                string varName = commandParts[1];
                if (!Int32.TryParse(commandParts[3], out int varValue))
                {
                    throw new GPLexceptions.InvalidParameterException("invalid value for variable.");
                }

                Variables.Add(varName, varValue);

            }
            else if (commandParts[0] == "vars")
            {
                foreach (KeyValuePair<string, int> kvp in Variables)
                {
                    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                }
            }
            else
            {
                throw new GPLexceptions.InvalidCommandException("Unknown command: " + commandParts[0]);
            }

        }
    }
}
