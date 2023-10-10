namespace Battleship.GameController.Tests.GameControllerTests
{
    using Battleship.GameController.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;
    using System.Collections.Generic;
    using Assert = NUnit.Framework.Assert;

    /// <summary>
    /// The is ship valid tests.
    /// </summary>
    [TestClass]
    public class IsShipValidTests
    {
        /// <summary>
        /// The ship is not valid.
        /// </summary>
        [TestCase(new object[] { "A1", "A2", "A3" }, ExpectedResult = true)]
        [TestCase(new object[] { "A1" }, ExpectedResult = false)]
        [TestCase(new object[] { "A1", "A2", "C6" }, ExpectedResult = false)]
        public bool ShipIsNotValid(object[] positions)
        {
            var ship = new Ship { Name = "TestShip", Size = 3 };
            foreach (var position in positions) { ship.AddPosition((string)position); }
            var result = GameController.IsShipValid(ship);

            return result;
        }

        /// <summary>
        /// The ship is valid.
        /// </summary>
        [TestMethod]
        public void ShipIsValid()
        {
            var positions = new List<Position> { new Position(Letters.A, 1), new Position(Letters.A, 1), new Position(Letters.A, 1) };

            var ship = new Ship { Name = "TestShip", Size = 3, Positions = positions };
            var result = GameController.IsShipValid(ship);

            Assert.IsTrue(result);
        }
    }
}