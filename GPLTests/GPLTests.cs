using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using ASE_Assignment;
using System.Collections.Generic;

namespace GPLTests
{
    /// <summary>
    /// Contains unit tests for CommandParser class.
    /// </summary>
    [TestClass]
    public class CommandParserTests
    {
        /// <summary>
        /// Tests for parsing single valid command.
        /// </summary>
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

        /// <summary>
        /// Test for parsing multiple valid commands.
        /// This test class contains 3 shapes, Circle, Triangle and Rectangle.
        /// It serves as a unit test for all three of these shapes as the test would not pass if the shapes were not implemented properly. 
        /// </summary>
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

        /// <summary>
        /// Test for parsing an invalid command.
        /// </summary>
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

        /// <summary>
        /// Test for parsing invalid parameter.
        /// </summary>
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

        /// <summary>
        /// Test for parsing moveTo command.
        /// </summary>
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

        /// <summary>
        /// Test for changing pen colour command.
        /// </summary>
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

        /// <summary>
        /// Test for fill command.
        /// </summary>
        [TestMethod]
        public void fillTest()
        {
            string command = "fill on";
            Pen p = new Pen(Color.Black, 2);
            Canvass canvas = new Canvass(p, 313, 393);
            CommandParser cp = new CommandParser(command, canvas, p);

            Assert.IsTrue(cp.IsFilled());
        }

        /// <summary>
        /// Test for while loop.
        /// </summary>
        [TestMethod]
        public void whileLoopTest()
        {
            string command = "var x = 0" + Environment.NewLine +
                             "while x < 10" + Environment.NewLine +
                             "circle 20" + Environment.NewLine +
                             "var x = x + 1" + Environment.NewLine +
                             "endwhile";
            Pen p = new Pen(Color.Black, 2);
            Canvass canvas = new Canvass(p, 313, 393);
            CommandParser cp = new CommandParser(command, canvas, p);

            Assert.AreEqual(10, canvas.GetShapes().Count);
        }

        /// <summary>
        /// Test for variable.
        /// </summary>
        [TestMethod]
        public void variableTest()
        {
            string command = "var x = 30" + Environment.NewLine +
                             "circle x";
            Pen p = new Pen(Color.Black, 2);
            Canvass canvas = new Canvass(p, 313, 393);
            CommandParser cp = new CommandParser(command, canvas, p);

            Assert.AreEqual(1, canvas.GetShapes().Count);
            Circle circle1 = (Circle)canvas.GetShapes()[0];
            Assert.AreEqual(30, circle1.GetRadius());
        }

        /// <summary>
        /// Test for variable expressions.
        /// </summary>
        [TestMethod]
        public void variableExpressionTest()
        {
            string command = "var x = 30" + Environment.NewLine +
                             "var y = x * 10" + Environment.NewLine +
                             "circle y";
            Pen p = new Pen(Color.Black, 2);
            Canvass canvas = new Canvass(p, 313, 393);
            CommandParser cp = new CommandParser(command, canvas, p);

            Assert.AreEqual(1, canvas.GetShapes().Count);
            Circle circle1 = (Circle)canvas.GetShapes()[0];
            Assert.IsNotNull(circle1);
            Assert.AreEqual(300, circle1.GetRadius());
        }

        /// <summary>
        /// Test for if commands.
        /// </summary>
        [TestMethod]
        public void ifCommandTest()
        {
            string command = "var x = 10" + Environment.NewLine +
                             "if x == 10" + Environment.NewLine +
                             "circle 20" + Environment.NewLine +
                             "endif";
            Pen p = new Pen(Color.Black, 2);
            Canvass canvas = new Canvass(p, 313, 393);
            CommandParser cp = new CommandParser(command, canvas, p);

            Assert.AreEqual(1, canvas.GetShapes().Count);
        }

        /// <summary>
        /// Test for methods.
        /// </summary>
        [TestMethod]
        public void methodsTest()
        {
            string command = "method drawShapes x y" + Environment.NewLine +
                             "circle x" + Environment.NewLine +
                             "triangle x y" + Environment.NewLine +
                             "rectangle x y" + Environment.NewLine +
                             "endmethod" + Environment.NewLine +
                             "call drawShapes 100 70";
            Pen p = new Pen(Color.Black, 2);
            Canvass canvas = new Canvass(p, 313, 393);
            CommandParser cp = new CommandParser(command, canvas, p);

            Assert.AreEqual(3, canvas.GetShapes().Count);

            Circle circle1 = (Circle)canvas.GetShapes()[0];
            Assert.IsNotNull(circle1);
            Assert.AreEqual(100, circle1.GetRadius());

            Triangle triangle = (Triangle)canvas.GetShapes()[1];
            Assert.IsNotNull(triangle);
            Assert.AreEqual(100, triangle.GetWidth());
            Assert.AreEqual(70, triangle.GetHeight());

            ASE_Assignment.Rectangle rect = (ASE_Assignment.Rectangle)canvas.GetShapes()[2];
            Assert.IsNotNull(rect);
            Assert.AreEqual(100, rect.GetWidth());
            Assert.AreEqual(70, rect.GetHeight());


        }
    }
}
