
using System.Collections.Generic;

namespace BowlingBall
{
    public class BowlingGame : IGame
    {
        #region Private Variables and Constants

        private const int FrameCount = 10;
        private List<int> rolls = new List<int>();

        #endregion;

        #region Public Methods

        /// <summary>
        /// To record the Rolls and Pins
        /// </summary>
        /// <param name="pins"></param>
        public void Roll(int pins)
        {
            rolls.Add(pins);
        }

        //To get the Score based on Rolls and Pins already recorded.
        public int GetScore()
        {
            var score = 0;
            var rollIndex = 0;

            for(var frame = 0; frame < FrameCount; frame++)
            {
                if(IsStrike(rollIndex))
                {
                    score += GetStrikeScore(rollIndex);
                    rollIndex++;
                }
                else if(IsSpare(rollIndex))
                {
                    score += GetSpareScore(rollIndex);
                    rollIndex += 2;
                }
                else
                {
                    score += GetStandardScore(rollIndex);
                    rollIndex += 2;
                }
            }
            return score;
        }
        #endregion;

        #region Private Methods

        private bool IsStrike(int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }

        private bool IsSpare(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
        }

        private int GetStandardScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1];
        }
        private int GetSpareScore(int rollIndex)
        {
            return GetStrikeScore(rollIndex); //Logic is same, but I am keeping separate methods for future change for logic secrecation
        }

        private int GetStrikeScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }

        #endregion;
    }
}
