﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using ASE_Assignment;
using System.Collections.Generic;

namespace GPLTests
{
    [TestClass]
    public class CommandParserTests
    {
        [TestMethod]
        public void singleCommandTest()
        {
            string command = "circle 20";
            Pen p = new Pen(Color.Black, 2);
            Canvass canvas = new Canvass(p, 313, 393);
            CommandParser cp = new CommandParser(command, canvas, p);

            Circle circle = (Circle)canvas.GetShapes()[0];

            Assert.AreEqual(1, canvas.GetShapes().Count);
            Assert.IsNotNull(circle);
            Assert.AreEqual(20, circle.GetRadius());
        }

        [TestMethod]
        public void multiCommandTest()
        {
            Pen p = new Pen(Color.Black, 2);
            string command = "circle 20" + Environment.NewLine + "moveTo 100 100" + Environment.NewLine + "triangle 60 100" + Environment.NewLine + "moveTo 50 50" + Environment.NewLine + "rectangle 100 50";
            Canvass canvas = new Canvass(p, 313, 393);
            CommandParser cp = new CommandParser(command, canvas, p);

            Assert.AreEqual(3, canvas.GetShapes().Count);

            Circle circle1 = (Circle)canvas.GetShapes()[0];
            Assert.IsNotNull(circle1);
            Assert.AreEqual(20, circle1.GetRadius());

            Triangle triangle = (Triangle)canvas.GetShapes()[1];
            Assert.IsNotNull(triangle);
            Assert.AreEqual(60, triangle.GetWidth());
            Assert.AreEqual(100, triangle.GetHeight());

            ASE_Assignment.Rectangle rect = (ASE_Assignment.Rectangle)canvas.GetShapes()[2];
            Assert.IsNotNull(rect);
            Assert.AreEqual(100, rect.GetWidth());
            Assert.AreEqual(50, rect.GetHeight());
        }

        [TestMethod]
        public void invalidCommandTest()
        {
            string command = "doodoo x";
            Pen p = new Pen(Color.Black, 2);
            Canvass canvas = new Canvass(p, 313, 393);

            Assert.ThrowsException<GPLexceptions.InvalidCommandException>(() =>
            {
                CommandParser cp = new CommandParser(command, canvas, p);
            });       
        }

        [TestMethod]
        public void invalidParameterTest()
        {
            string command = "circle x";
            Pen p = new Pen(Color.Black, 2);
            Canvass canvas = new Canvass(p, 313, 393);

            Assert.ThrowsException<GPLexceptions.InvalidParameterException>(() =>
            {
                CommandParser cp = new CommandParser(command, canvas, p);
            });
        }

        [TestMethod]
        public void moveToTest()
        {
            string command = "moveTo 100 100";
            Pen p = new Pen(Color.Black, 2);
            Canvass canvas = new Canvass(p, 313, 393);
            CommandParser cp = new CommandParser(command, canvas, p);

            Point point = canvas.GetPoint();
            Assert.AreEqual(100, point.X);
            Assert.AreEqual(100, point.Y);
        }

        [TestMethod]
        public void penColourTest()
        {
            Pen p = new Pen(Color.Black, 2);
            string command = "pen red";
            Canvass canvas = new Canvass(p, 313, 393);
            CommandParser cp = new CommandParser(command, canvas, p);

            Pen testPen = canvas.GetPen();

            Assert.AreEqual(Color.Red, testPen.Color);
        }

        [TestMethod]
        public void fillTest()
        {
            string command = "fill on";
            Pen p = new Pen(Color.Black, 2);
            Canvass canvas = new Canvass(p, 313, 393);
            CommandParser cp = new CommandParser(command, canvas, p);

            Assert.IsTrue(cp.isFilled());
        }
    }
}
