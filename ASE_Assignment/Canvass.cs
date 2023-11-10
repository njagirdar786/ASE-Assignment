using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    /// <summary>
    /// Represents a canvas for drawing onto. It graphically represents the commands the user enters.
    /// </summary>
    public class Canvass
    {

        private Bitmap myBitmap; // Bitmap represents the canvas
        private Graphics g; // GDI+ Graphics
        private Point p; // The current drawing position/point
        private Pen pen; // Pen used for drawing.
        private List<Shape> drawnShapes; // List of shapes currently drawn on the canvas

        /// <summary>
        /// Initialises new instance of Canvass class.
        /// </summary>
        /// <param name="pen">Pen used for drawing.</param>
        /// <param name="width">Width of the canvas.</param>
        /// <param name="height">Height of the canvas.</param>
        public Canvass(Pen pen, int width, int height)
        {
            myBitmap = new Bitmap(width, height);
            g = Graphics.FromImage(myBitmap);
            this.pen = pen;
            drawnShapes = new List<Shape>();

        }

        /// <summary>
        /// Draws a shape on the canvas using the draw method on the shape class. 
        /// </summary>
        /// <param name="shape">The shape to be drawn.</param>
        /// <param name="fill">Boolean that determines to use fill or not</param>
        public void DrawShape(Shape shape, bool fill)
        {
            shape.draw(g, p, pen, fill);
            drawnShapes.Add(shape);
        }

        /// <summary>
        /// Gets a list of shapes currently drawn on the canvas.
        /// </summary>
        /// <returns>A list of shapes.</returns>
        public List<Shape> GetShapes()
        {
            return drawnShapes;
        }

        /// <summary>
        /// Clears the list of drawn shapes. Executed within the clear command in CommandParser.
        /// </summary>
        public void ClearShapeList()
        {
            drawnShapes.Clear();
        }

        /// <summary>
        /// Gets the bitmap that represents the canvas.
        /// </summary>
        /// <returns>The bitmap representing the canvas.</returns>
        public Bitmap GetBitmap()
        {
            return myBitmap;
        }

        /// <summary>
        /// Moves the drawing position/point to coordinates entered.
        /// </summary>
        /// <param name="x">X position to move to.</param>
        /// <param name="y">Y position to move to</param>
        public void MoveTo(int x, int y)
        {
            p = new Point(x, y);
        }

        /// <summary>
        /// Gets the current drawing position on the canvas.
        /// </summary>
        /// <returns>Current point.</returns>
        public Point GetPoint()
        {
            return p;
        }

        /// <summary>
        /// Gets the current pen.
        /// </summary>
        /// <returns>The current pen.</returns>
        public Pen GetPen()
        {
            return pen;
        }

        /// <summary>
        /// Draws a line from current position to the specified coordinates entered.
        /// </summary>
        /// <param name="pen">The pen used for drawing.</param>
        /// <param name="x">X position of the lines end point</param>
        /// <param name="y">Y position of the lines end point</param>
        public void DrawLine(Pen pen, int x, int y)
        {
            g.DrawLine(pen, p.X, p.Y, x, y);
        }

        /// <summary>
        /// Clears the canvas with a DarkGray colour.
        /// </summary>
        public void Clear()
        {
            g.Clear(Color.DarkGray);   
        }

        /// <summary>
        /// Resets the Point position to its initial state - 0,0.
        /// </summary>
        public void Reset()
        {
            p.X = 0; 
            p.Y = 0;
        }

    }
}
