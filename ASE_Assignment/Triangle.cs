using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Triangle:Shape
    {
        protected int width;
        protected int height;
        
        public Triangle(Color colour, int x, int y, int width, int height) : base(colour, x, y)
        {
            this.width = width;
            this.height = height;
        }

        public int GetWidth() { return width; }
        public int GetHeight() { return height; }

        public override void draw(Graphics g, Point point, Pen pen, bool fill)
        {

            Point v1 = point;
            Point v2 = new Point(point.X + width, point.Y);
            Point v3 = new Point(point.X + (width / 2), point.Y - height);

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
