using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Battleship.GameController.Contracts
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The ship.
    /// </summary>
    public class Ship
    {
        private bool isPlaced;

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Ship"/> class.
        /// </summary>
        public Ship()
        {
            Positions = new List<Position>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the positions.
        /// </summary>
        public List<Position> Positions { get; set; }

        /// <summary>
        /// The color of the ship
        /// </summary>
        public ConsoleColor Color { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        public int Size { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add position.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        public void AddPosition(string input)
        {
            if (Positions == null)
            {
                Positions = new List<Position>();
            }

            var letter = (Letters)Enum.Parse(typeof(Letters), input.ToUpper().Substring(0, 1));
            var number = int.Parse(input.Substring(1, 1));
            Positions.Add(new Position { Column = letter, Row = number });
        }

        public bool ArePositionsValid()
        {
            // if (Positions.Count < 2)
            // {
            //     // If the ship has only one position, it's valid.
            //     return true;
            // }

            // Check if all positions have the same row (for horizontal) or the same column (for vertical).
            var firstPosition = Positions[0];
            bool isHorizontal = true;
            bool isVertical = true;

            for (int i = 1; i < Positions.Count; i++)
            {
                if (Positions[i].Row != firstPosition.Row)
                {
                    isHorizontal = false;
                }

                if (Positions[i].Column != firstPosition.Column)
                {
                    isVertical = false;
                }
            }

            // The ship is valid if it's either horizontal or vertical.
            return isHorizontal || isVertical;
        }


        public bool IsPlaced
        {
            get { return isPlaced; }
            set
            {
                if (value.Equals(isPlaced)) return;
                isPlaced = value;
            }
        }
        #endregion
    }
}