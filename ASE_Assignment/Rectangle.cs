using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    internal class Rectangle:Shape
    {
        protected int width;
        protected int height;
        public Rectangle(Color colour, int x, int y, int width, int height) : base(colour, x, y)
        {
            this.width = width;
            this.height = height;
        }
        public override void draw(Graphics g, Point point, Pen pen)
        {
            g.DrawRectangle(pen, point.X, point.Y, width, height);
        }
    }
}
