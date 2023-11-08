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

        public Canvass(Pen pen, int width, int height)
        {
            myBitmap = new Bitmap(width, height);
            g = Graphics.FromImage(myBitmap);
            this.pen = pen;

        }

        public void DrawShape(Shape shape, bool fill)
        {
            shape.draw(g, p, pen, fill);
        }

        public Bitmap GetBitmap()
        {
            return myBitmap;
        }


        public void MoveTo(int x, int y)
        {
            p = new Point(x, y);
        }

        public void DrawLine(Pen pen, int x, int y)
        {
            g.DrawLine(pen, p.X, p.Y, x, y);
        }

        public void Clear()
        {
            g.Clear(Color.DarkGray);   
        }

        public void Reset()
        {
            p.X = 0; 
            p.Y = 0;
        }

    }
}
