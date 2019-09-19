using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGame = BowlingGame.BowlingGame;

namespace BowlingGameUnitTests
{
    [TestClass]
    public class BowlingGameUnitTests
    {
        private global::BowlingGame.BowlingGame sut;
        [TestInitialize]
        public void TestInitialize()
        {
            sut = new global::BowlingGame.BowlingGame();
        }

        [TestMethod]
        public void TestGutterGame_Should_Return_Zero()
        {
            int rolls = 10;
            int pinsknocked = 0;

            RollMultiplePins(rolls, pinsknocked);

            Assert.AreEqual(0, sut.Score());
        }

        [TestMethod]
        public void Test_all_Ones_Return_20()
        {
            int rolls = 20;
            int pinsknocked = 1;

            RollMultiplePins(rolls, pinsknocked);

            Assert.AreEqual(20, sut.Score());
        }

        void RollMultiplePins(int rolls, int pinsknocked)
        {
            for (int i = 0; i < rolls; i++)
            {
                sut.Roll(pinsknocked);
            }
        }

        [TestMethod]
        public void Test_One_Spare()
        {
            sut.Roll(5);
            sut.Roll(5);
            sut.Roll(3);

            RollMultiplePins(17, 0);

            Assert.AreEqual(16, sut.Score());
        }

        [TestMethod]
        public void Test_One_Strike()
        {
            rollStrike();
            sut.Roll(4);
            sut.Roll(5);

            RollMultiplePins(16, 0);

            Assert.AreEqual(28, sut.Score());
        }

        [TestMethod]
        public void Test_PerfectGame()
        {
            RollMultiplePins(12, 10);

            Assert.AreEqual(300, sut.Score());
        }

        private void rollStrike()
        {
            sut.Roll(10);
        }
    }




}
