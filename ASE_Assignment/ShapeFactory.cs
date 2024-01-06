using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// Implements factory design pattern for shape creation.
    /// </summary>
    public class ShapeFactory
    {
        /// <summary>
        /// Creates an instance of a shape based on given parameters.
        /// </summary>
        /// <param name="shapeType">Name of the shape.</param>
        /// <param name="color">Color of the shape.</param>
        /// <param name="x">X position of the shape.</param>
        /// <param name="y">Y position of the shape.</param>
        /// <param name="parameters">Width/Height for rectangle/triangle - Radius for circles.</param>
        /// <returns>A new instance of a shape.</returns>
        /// <exception cref="Exception">Exeception when shapeType is not recognised.</exception>
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
