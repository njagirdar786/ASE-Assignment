﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    internal class Canvass
    {

        private Bitmap myBitmap;
        private Graphics g;
        private Point p;
        private Pen pen;

        public Canvass(Pen pen,int width, int height)
        {
            myBitmap = new Bitmap(width, height);
            g = Graphics.FromImage(myBitmap);
            this.pen = pen;
            

        }

        public void DrawShape(Shape shape)
        {
            shape.draw(g, p);
        }

        public Bitmap GetBitmap()
        {
            return myBitmap;
        }

        public void MoveTo(int x, int y)
        {
            p = new Point(x, y);
        }

        public void DrawLine(int x, int y)
        {
            g.DrawLine(pen, p.X, p.Y, x, y);
        }
    }
}
