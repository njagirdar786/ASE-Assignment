using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class ShapeFactory
    {
        public Shape CreateShape(string shapeType, Color color, int x, int y, params int[] parameters)
        {
            if (shapeType.ToLower() == "circle" && parameters.Length == 1)
            {
                return new Circle(color, x, y, parameters[0]);
            }
            else if (shapeType.ToLower() == "rectangle" && parameters.Length == 2)
            {
                return new Rectangle(color, x, y, parameters[0], parameters[1]);
            } 
            else if(shapeType.ToLower() == "triangle" && parameters.Length == 2)
            {
                return new Triangle(color, x, y, parameters[0], parameters[1]);
            }
            else
            {
                throw new Exception("Invalid shape type: " + shapeType);
            }
        }

    }
}
