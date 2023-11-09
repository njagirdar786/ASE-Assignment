using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Rectangle:Shape
    {
        protected int width;
        protected int height;
        public Rectangle(Color colour, int x, int y, int width, int height) : base(colour, x, y)
        {
            this.width = width;
            this.height = height;
        }

        public int GetWidth() {  return width; }
        public int GetHeight() { return height; }   

        public override void draw(Graphics g, Point point, Pen pen, bool fill)
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
