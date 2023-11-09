using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using ASE_Assignment;

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

            Assert.IsNotNull(cp);

            
        }
    }
}
