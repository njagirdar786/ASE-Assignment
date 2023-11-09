using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            Assert.AreEqual(1, canvas.GetShapes().Count);

            Circle circle = (Circle)canvas.GetShapes()[0]; 

            Assert.IsNotNull(circle);
            Assert.AreEqual(20, circle.GetRadius());

            
        }
    }
}
