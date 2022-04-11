using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace minesweep
{
    [TestClass]
    public class TestClass
    {
        [TestMethod]
         public void TestDisplayMethod () {
             Display display = new Display();
              string intro = "▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄\n"+
                             "██ ▄▀▄ ██▄██ ▄▄▀█ ▄▄██ ▄▄▄ █ ███ █ ▄▄█ ▄▄█▀▄▄▀█ ▄▄█ ▄▄▀██\n"+
                             "██ █ █ ██ ▄█ ██ █ ▄▄██▄▄▄▀▀█▄▀ ▀▄█ ▄▄█ ▄▄█ ▀▀ █ ▄▄█ ▀▀▄██\n"+
                             "██ ███ █▄▄▄█▄██▄█▄▄▄██ ▀▀▀ ██▄█▄██▄▄▄█▄▄▄█ ████▄▄▄█▄█▄▄██\n"+
                             "▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ";  
             Assert.AreEqual(intro, display.Intro(), "Display Title not shown"); 

         }
        
    }
}
