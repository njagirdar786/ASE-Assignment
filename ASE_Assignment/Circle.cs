﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    internal class Circle:Shape
    {
        protected int radius;

        public Circle(Color colour, int x, int y, int radius) : base(colour, x, y)
        {
            this.radius = radius;
        }

        public override void draw(Graphics g, Point point, Pen pen, bool fill)
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