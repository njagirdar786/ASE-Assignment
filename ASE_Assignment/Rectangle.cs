using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// Represents a rectangle that can be drawn on the canvas.
    /// </summary>
    public class Rectangle:Shape
    {
        protected int width;
        protected int height;

        /// <summary>
        /// Initialises new instance of rectangle with colour, x and y position, width and height.
        /// </summary>
        /// <param name="colour">Colour of the rectangle.</param>
        /// <param name="x">X position of the rectangle.</param>
        /// <param name="y">Y position of the rectangle.</param>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        public Rectangle(Color colour, int x, int y, int width, int height) : base(colour, x, y)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Gets width of rectangle.
        /// </summary>
        /// <returns>Width of rectangle.</returns>
        public int GetWidth() {  return width; }
        /// <summary>
        /// Gets Height of rectangle.
        /// </summary>
        /// <returns>Height of rectangle.</returns>
        public int GetHeight() { return height; }

        /// <summary>
        /// Draws the rectangle on the canvas using specified pen and fill state.
        /// </summary>
        /// <param name="g">GDI+ Grpahics object.</param>
        /// <param name="point">Position to draw the shape.</param>
        /// <param name="pen">Pen for drawing the shape.</param>
        /// <param name="fill">Boolean determining to fill the shape or not.</param>
        public override void Draw(Graphics g, Point point, Pen pen, bool fill)
        {
            if (fill == true)
            {
                SolidBrush brush = new SolidBrush(pen.Color);
                g.DrawRectangle(pen, point.X, point.Y, width, height);
                g.FillRectangle(brush, point.X, point.Y, width, height);
            }
            else
            {
                g.DrawRectangle(pen, point.X, point.Y, width, height);
            }
        }
    }
}
