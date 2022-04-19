using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace minesweep
{
    [TestClass]
    public class TestTile
    {
        [TestMethod]
        public void TestIsMine()
        {
            Tile tile = new Tile();
            bool isMine = false;
            Assert.AreEqual(isMine, tile.IsMine(), "Boolean not initialised correctly.");
        }
    }
}