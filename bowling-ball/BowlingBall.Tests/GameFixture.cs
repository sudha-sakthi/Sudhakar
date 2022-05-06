using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        #region Private Variables
        private IGame game = null;
        #endregion

        #region Test Initializer Methods
        [TestInitialize]
        public void InitializedGame()
        {
            this.game = new BowlingGame(); //Keeping Interface and object initization here to apply these test for different game in future. It will maintain loosely coupled dependency.
        }
        #endregion;

        #region Public test Methods

        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            Roll(game, 0, 20);
            Assert.AreEqual(0, game.GetScore());
        }

        public void Gutter_game_score_should_be_twenty_for_all_in_one_test()
        {
            Roll(game, 0, 20);
            Assert.AreEqual(20, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_sixteen_for_roll_space_test()
        {
            var game = new BowlingGame();
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            Roll(game, 0, 17);
            Assert.AreEqual(16, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_twenty_four_for_roll_srike_test()
        {
            var game = new BowlingGame();
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);
            Roll(game, 0, 16);
            Assert.AreEqual(24, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_three_hunder_for_perfect_game_test()
        {
            var game = new BowlingGame();
            Roll(game, 10, 12);
            Assert.AreEqual(300, game.GetScore());
        }

        #endregion;

        #region Private Methods
        private void Roll(IGame game, int pins, int times)
        {
            for(var rollIndex = 0; rollIndex < times; rollIndex++)
            {
                game.Roll(pins);
            }
        }
        #endregion;
    }
}
