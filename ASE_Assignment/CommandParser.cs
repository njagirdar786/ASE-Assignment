﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace ASE_Assignment
{
    /// <summary>
    /// Parses and executes commands
    /// </summary>
    public class CommandParser
    {
        bool fill = false;

        // Test method for checking if fill is true or false
        public bool IsFilled()
        {
            return fill;
        }

        //collects all error messages from caught exceptions.
        List<string> errors = new List<string>(); 

        /// <summary>
        /// Retrieves errors in the program.
        /// </summary>
        /// <returns>A list containing error messages.</returns>
        public List<string> GetErrors()
        {
            return errors;
        }

        //Dictionary to store variables, key -> value pairs
        private Dictionary<string, int> Variables = new Dictionary<string, int>();

        //Dictionairy to store Methods and their commands 
        private Dictionary<string, List<string>> Methods = new Dictionary<string, List<string>>();

        //Dictionairy to store Method parameters
        private Dictionary<string, List<string>> MethodsWithParams = new Dictionary<string, List<string>>();

        /// <summary>
        /// Checks if given string is a variable within the variables dictionairy or if it is a valid integer.
        /// </summary>
        /// <param name="varOrValue">String to check if it is a variabe or value.</param>
        /// <returns>The value from the variable or the value itself.</returns>
        /// <exception cref="GPLexceptions.InvalidParameterException">Exception when string is not a valid variable or value.</exception>
        private int CheckVarOrValue(string varOrValue)
        {
            if (Variables.ContainsKey(varOrValue))
            {
                return Variables[varOrValue];
            }
            else if (Int32.TryParse(varOrValue, out int value))
            {
                return value;
            }
            else
            {
                throw new GPLexceptions.InvalidParameterException("Invalid variable or value " + varOrValue);
                
            }
        }

        /// <summary>
        /// Evaluates condition expressions for while loops and if statements.
        /// </summary>
        /// <param name="condition">The condition expression to evaluate.</param>
        /// <returns>The result of the condiition evaluation.</returns>
        /// <exception cref="GPLexceptions.InvalidCommandException">Exception when the comparitor is invalid.</exception>
        private bool EvaluateCondition(string condition)
        {
            string[] conditionParts = condition.Split(' ');
            
            int var1 = CheckVarOrValue(conditionParts[0]);
            string comparator = conditionParts[1];
            int var2 = CheckVarOrValue(conditionParts[2]);

            switch (comparator)
            {
                case "<":
                    return var1 < var2;
                case ">":
                    return var1 > var2;
                case "==":
                    return var1 == var2;
                default: 
                    throw new GPLexceptions.InvalidCommandException(comparator + " is not a valid comparitor, use < or >");
            }
                    

        }

        /// <summary>
        /// Evaluates mathimatical expressions for variables.
        /// </summary>
        /// <param name="expression">The mathematical expression to be evaluated.</param>
        /// <returns>The result of the mathematical expression.</returns>
        private int EvaluateExpression(string expression)
        {
            foreach (var v in Variables)
            {
                expression = expression.Replace(v.Key, v.Value.ToString());
            }

            DataTable dt = new DataTable();
            return Convert.ToInt32(dt.Compute(expression, ""));
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

            /*foreach (string c in commands)
            {
                    ParseIndividualCommand(c, canvas, pen);
            }*/

            for (int i = 0; i < commands.Length; i++)
            {
                try { 
                    if (commands[i].StartsWith("while"))
                    {
                        string condition = commands[i].Substring(6);
                        List<string> whileLoopCommands = new List<string>();

                        i++;
                        while (!commands[i].StartsWith("endwhile"))
                        {
                            whileLoopCommands.Add(commands[i]);
                            i++;
                            if (i >= commands.Length)
                            {
                                throw new GPLexceptions.InvalidCommandException("Missing endwhile for while command");
                            }
                        }

                        while (EvaluateCondition(condition))
                        {
                            foreach (var cmd in whileLoopCommands)
                            {
                                Console.WriteLine(cmd);
                                ParseIndividualCommand(cmd, canvas, pen, i);
                            }
                        }
                    
                    }
                    else if (commands[i].StartsWith("if"))
                    {
                        string condition = commands[i].Substring(3);
                        List<string> ifCommands = new List<string>();

                        i++;
                        while (!commands[i].StartsWith("endif"))
                        {
                            ifCommands.Add(commands[i]);
                            i++;
                            if (i >= commands.Length)
                            {
                                throw new GPLexceptions.InvalidCommandException("Missing endif for if command");
                            }
                        }

                        if (EvaluateCondition(condition))
                        {
                            foreach (var cmd in ifCommands)
                            {
                                Console.WriteLine(cmd);
                                ParseIndividualCommand(cmd, canvas, pen, i);
                            }
                        }

                    }
                    else if (commands[i].StartsWith("method")){

                        string[] commandParts = commands[i].Split(' ');

                        string methodName = commandParts[1];
                        List<string> methodCommands = new List<string>();
                        List<string> methodParams = new List<string>();

                        i++;
                        while (!commands[i].StartsWith("endmethod"))
                        {
                            methodCommands.Add(commands[i]);
                            i++;
                            if (i >= commands.Length)
                            {
                                throw new GPLexceptions.InvalidCommandException("Missing endmethod for method command");
                            }
                        }
                        if (commandParts.Length > 2)
                        {
                            methodParams = commandParts.Skip(2).ToList();
                            Methods[methodName] = methodCommands;
                            MethodsWithParams[methodName] = methodParams;

    /*                        foreach(var p in methodParams)
                            {
                                Console.WriteLine(p);
                            }*/
                        } 
                        else
                        {
                            Methods[methodName] = methodCommands;
                        }

                    }
                    else
                    {
                        ParseIndividualCommand(commands[i], canvas, pen, i);
                    }
                }
                catch (GPLexceptions.InvalidCommandException e)
                {
                    errors.Add("line " + i + ": " + e.Message);
                }
                catch(GPLexceptions.InvalidParameterException e)
                {
                    errors.Add("line " + i + ": " + e.Message);
                }

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
        private void ParseIndividualCommand(string command, Canvass canvas, Pen pen, int lineNumber)
        {
            string[] commandParts = command.Split(' ');

            ShapeFactory sf = new ShapeFactory();
            
            try { 
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

                    int radius = CheckVarOrValue(commandParts[1]);

                    if (radius <= 0)
                    {
                        throw new GPLexceptions.InvalidParameterException("radius must be a positive integer");
                    }

                    Shape circle = sf.CreateShape("circle", pen.Color, 10, 10, radius);
                    canvas.DrawShape(circle, fill);
                }
                else if (commandParts[0] == "rectangle")
                {

                    if (commandParts.Length != 3)
                    {
                        throw new GPLexceptions.InvalidCommandException("invalid number of paramters for rectangle command");
                    }

                    int width = CheckVarOrValue(commandParts[1]);
                    int height = CheckVarOrValue(commandParts[2]);

                    if (width <= 0 || height <= 0)
                    {
                        throw new GPLexceptions.InvalidParameterException("rectangle width and height must be a positive integers");
                    }

                    Shape rectangle = sf.CreateShape("rectangle", pen.Color, 10, 10, width, height);
                    canvas.DrawShape(rectangle, fill);
                }
                else if (commandParts[0] == "triangle")
                {
                    if (commandParts.Length != 3)
                    {
                        throw new GPLexceptions.InvalidCommandException("invalid number of paramters for triangle command");
                    }

                    int width = CheckVarOrValue(commandParts[1]);
                    int height = CheckVarOrValue(commandParts[2]);

                    if (width <= 0 || height <= 0)
                    {
                        throw new GPLexceptions.InvalidParameterException("triangle width and height must be a positive integers");
                    }

                    Shape triangle = sf.CreateShape("triangle", pen.Color, 10, 10, width, height);
                    canvas.DrawShape(triangle, fill);
                }
                else if (commandParts[0] == "moveTo")
                {

                    if (commandParts.Length != 3)
                    {
                        throw new GPLexceptions.InvalidCommandException("invalid number of paramters for moveTo command");
                    }

                    int x = CheckVarOrValue(commandParts[1]);
                    int y = CheckVarOrValue(commandParts[2]);

                    if (x <= 0 || y <= 0)
                    {
                        throw new GPLexceptions.InvalidParameterException("moveTo x and y must be a positive integers");
                    }

                    canvas.MoveTo(x, y);
                }
                else if (commandParts[0] == "drawLine")
                {

                    if (commandParts.Length != 3)
                    {
                        throw new GPLexceptions.InvalidCommandException("invalid number of paramters for drawLine command");
                    }

                    int x = CheckVarOrValue(commandParts[1]);
                    int y = CheckVarOrValue(commandParts[2]);

                    if (x <= 0 || y <= 0)
                    {
                        throw new GPLexceptions.InvalidParameterException("drawLine x and y must be a positive integers");
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

                    if (commandParts[1] != "red" && commandParts[1] != "green" && commandParts[1] != "blue" && commandParts[1] != "black")
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
                    if (commandParts.Length < 4 || commandParts[2] != "=")
                    {
                        throw new GPLexceptions.InvalidCommandException("invalid syntax for var command");
                    }

                    string expression = string.Join(" ", commandParts.Skip(3));
                    string varName = commandParts[1];

                    try
                    {
                        if (Int32.TryParse(commandParts[3], out int varValue))
                        {
                            Variables[varName] = varValue;
                        }
                        else {
                            int expressionValue = EvaluateExpression(expression);
                            Variables[varName] = expressionValue;
                        }
                    } catch (Exception ex)
                    {
                        throw new GPLexceptions.InvalidParameterException("invalid value for variable.");
                    }




                }
                else if (commandParts[0] == "vars")
                {
                    foreach (KeyValuePair<string, int> kvp in Variables)
                    {
                        Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                    }
                }
                else if (commandParts[0] == "endwhile")
                {
                    Console.WriteLine("endwhile called");
                }
                else if (commandParts[0] == "endif")
                {
                    Console.WriteLine("endif called");
                }
                else if (commandParts[0] == "call")
                {
                    string methodName = commandParts[1];
                    //Console.WriteLine(methodName);

                    if (Methods.ContainsKey(methodName))
                    {
                        foreach (var cmd in Methods[methodName])
                        {
                            string replacedCmd = cmd;
                            if (MethodsWithParams.ContainsKey(methodName))
                            {
                                List<string> givenParams = commandParts.Skip(2).ToList();
                                for (int i = 0; i < MethodsWithParams[methodName].Count; i++)
                                {
                                    replacedCmd = replacedCmd.Replace(MethodsWithParams[methodName][i], givenParams[i]);
                                    Console.WriteLine(replacedCmd);
                                }
                            }
                            ParseIndividualCommand(replacedCmd, canvas, pen, lineNumber);
                        }
                    }
                    else
                    {
                        throw new GPLexceptions.InvalidCommandException(methodName + " - this method does not exist");
                    }
                }
                else
                {
                    throw new GPLexceptions.InvalidCommandException("Unknown command: " + commandParts[0]);
                }
            }
            catch (GPLexceptions.InvalidCommandException e)
            {
                errors.Add("line " + lineNumber + ": " + e.Message);
            }
            catch (GPLexceptions.InvalidParameterException e)
            {
                errors.Add("line " + lineNumber + ": " + e.Message);
            }

        }
    }
}
