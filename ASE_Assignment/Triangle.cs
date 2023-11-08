using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    internal class Triangle:Shape
    {
        protected int side1;
        protected int side2;
        protected int side3;
        public Triangle(Color colour, int x, int y, int side1, int side2, int side3) : base(colour, x, y)
        {
            this.side1 = side1; 
            this.side2 = side2; 
            this.side3 = side3; 
        }
        public override void draw(Graphics g, Point point)
        {
            Pen p = new Pen(colour, 2);

            Point v1 = point;
            Point v2 = new Point(point.X + side1, point.Y);
            Point v3 = new Point(point.X + side2, point.Y - side3);

            Point[] vertices = { v1, v2, v3 };

            g.DrawPolygon(p, vertices);

        }
    }
}
