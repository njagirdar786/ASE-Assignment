using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// Represents a triangle that can be drawn on the canvas.
    /// </summary>
    public class Triangle:Shape
    {
        protected int width;
        protected int height;
        
        /// <summary>
        /// Initialises new instance of triangle with colour, x and y position, width and height.
        /// </summary>
        /// <param name="colour">Colour of the triangle.</param>
        /// <param name="x">X position of the triangle.</param>
        /// <param name="y">Y position of the triangle.</param>
        /// <param name="width">Width of the triangle.</param>
        /// <param name="height">Height of the triangle.</param>
        public Triangle(Color colour, int x, int y, int width, int height) : base(colour, x, y)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Gets width of the triangle.
        /// </summary>
        /// <returns>Width of the triangle.</returns>
        public int GetWidth() { return width; }
        /// <summary>
        /// Gets the height of the triangle.
        /// </summary>
        /// <returns>Height of the triangle.</returns>
        public int GetHeight() { return height; }

        /// <summary>
        /// Draws the triangle on the canvas using specified pen and fill state.
        /// </summary>
        /// <param name="g">GDI+ Grpahics object.</param>
        /// <param name="point">Position to draw the shape.</param>
        /// <param name="pen">Pen for drawing the shape.</param>
        /// <param name="fill">Boolean determining to fill the shape or not.</param>
        public override void Draw(Graphics g, Point point, Pen pen, bool fill)
        {

            //defines vertices of triangle
            Point v1 = point; // left
            Point v2 = new Point(point.X + width, point.Y); //right
            Point v3 = new Point(point.X + (width / 2), point.Y - height); //top

            //point array for DrawPolygon method
            Point[] vertices = { v1, v2, v3 };


            if (fill == true)
            {
                SolidBrush brush = new SolidBrush(pen.Color);
                g.DrawPolygon(pen, vertices);
                g.FillPolygon(brush, vertices);
            }
            else
            {
                g.DrawPolygon(pen, vertices);
            }

        }
    }
}
