using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// Represents a circle that can be drawn on the canvas.
    /// </summary>
    public class Circle:Shape
    {
        protected int radius;

        /// <summary>
        /// Initialises new instance of the circle class with colour, x and y position and radius.
        /// </summary>
        /// <param name="colour">Colour of the circle.</param>
        /// <param name="x">X position of the circle.</param>
        /// <param name="y">Y position of the circle.</param>
        /// <param name="radius">Radius of the circle.</param>
        public Circle(Color colour, int x, int y, int radius) : base(colour, x, y)
        {
            this.radius = radius;
        }

        /// <summary>
        /// Gets the radius of the circle.
        /// </summary>
        /// <returns>The radius of the circle.</returns>
        public int GetRadius()
        {
            return radius;
        }

        /// <summary>
        /// Draws the circle on the canvas using specified pen and fill state.
        /// </summary>
        /// <param name="g">GDI+ Grpahics object.</param>
        /// <param name="point">Position to draw the shape.</param>
        /// <param name="pen">Pen for drawing the shape.</param>
        /// <param name="fill">Boolean determining to fill the shape or not.</param>
        public override void Draw(Graphics g, Point point, Pen pen, bool fill)
        {
            
            if(fill == true)
            {
                SolidBrush brush = new SolidBrush(pen.Color);
                g.DrawEllipse(pen, point.X, point.Y, radius * 2, radius * 2);
                g.FillEllipse(brush, point.X, point.Y, radius * 2, radius * 2);
            }
            else
            {
                g.DrawEllipse(pen, point.X, point.Y, radius * 2, radius * 2);
            }

        }
    }
}
