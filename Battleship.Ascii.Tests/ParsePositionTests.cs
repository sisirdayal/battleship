
namespace Battleship.Ascii.Tests
{
    using Battleship.GameController;
    using Battleship.GameController.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using Assert = NUnit.Framework.Assert;

    [TestClass]
    public class ParsePositionTests
    {
        private static List<Ship> enemyFleet;

        [TestMethod]
        public void ParseLetterNumber()
        {
            var actual = Program.ParsePosition("A1");

            var expected = new Position(Letters.A, 1);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void InitializeEnemyFleet()
        {
            enemyFleet = GameController.InitializeShips().ToList();

            Program.InitializeEnemyFleet();

            foreach (Ship ship in enemyFleet)
            {
                Assert.IsNotNull(ship.Positions);
            }
        }
    }
}
