using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    abstract class Shape
    {
        protected Color colour;
        protected int x, y;

        public Shape(Color colour, int x, int y)
        {
            this.colour = colour;
            this.x = x;
            this.y = y;
        }

        public abstract void draw(Graphics g, Point point);

        public override string ToString()
        {
            return base.ToString() + x + " " + y;
        }
    }
}
