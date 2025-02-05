﻿namespace Battleship.GameController.Tests.GameControllerTests
{
    using Battleship.GameController.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NUnit.Framework;

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
        [TestCase(new object[] { "A1", "A3", "A4" }, ExpectedResult = false)]
        public bool ShipValidity(object[] positions)
        {
            var ship = new Ship { Name = "TestShip", Size = 3 };
            foreach (var position in positions) { ship.AddPosition((string)position); }
            var result = GameController.IsShipValid(ship);

            return result;
        }
    }
}