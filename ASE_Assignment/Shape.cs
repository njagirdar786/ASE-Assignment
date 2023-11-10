using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// Represents an abstract shape with common properties - color and x,y position.
    /// </summary>
    public abstract class Shape
    {
        protected Color colour;
        protected int x, y;

        /// <summary>
        /// Initialises new instance of Shape class with desired colour and x,y position.
        /// </summary>
        /// <param name="colour">Color of the shape.</param>
        /// <param name="x">X position of the shape.</param>
        /// <param name="y">Y position of the shape.</param>
        public Shape(Color colour, int x, int y)
        {
            this.colour = colour;
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Draws the shape on the canvas using specified pen and fill state.
        /// </summary>
        /// <param name="g">GDI+ Grpahics object.</param>
        /// <param name="point">Position to draw the shape.</param>
        /// <param name="pen">Pen for drawing the shape.</param>
        /// <param name="fill">Boolean determining to fill the shape or not.</param>
        public abstract void draw(Graphics g, Point point, Pen pen, bool fill);


        public override string ToString()
        {
            return base.ToString() + x + " " + y;
        }
    }
}
