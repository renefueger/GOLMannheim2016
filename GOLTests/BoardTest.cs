namespace GOLTests
{
    using FakeItEasy;
    using GOLMannheim2016.Model;
    using NUnit.Framework;

    [TestFixture]
    public class BoardTest
    {
        [Test]
        [TestCase(5)]
        [TestCase(8)]
        [TestCase(3)]
        [TestCase(7)]
        [TestCase(2)]
        public void SettingWidthOfABoardShouldResultInCorrectWidth(int givenWidth)
        {
            var board = new Board(givenWidth, 0);


            Assert.That(board.Width, Is.EqualTo(givenWidth));
        }

        [Test]
        [TestCase(5)]
        [TestCase(8)]
        [TestCase(3)]
        [TestCase(7)]
        [TestCase(2)]
        public void SettingHeightOfABoardShouldResultInCorrectHeight(int givenHeight)
        {
            var board = new Board(0, givenHeight);


            Assert.That(board.Height, Is.EqualTo(givenHeight));
        }

        [Test]
        public void BoardWithZeroDimensionsShouldResultInEmptyString()
        {
            var board = new Board(0, 0);
            Assert.That(board.ToString(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void BoardWithDimensionOneShouldResultInCorrectString()
        {
            var board = new Board(1, 1);

            var expectedString = "-";
            Assert.That(board.ToString(), Is.EqualTo(expectedString));
        }

        [Test]
        public void BoardWithDimensionTwoShouldResultInCorrectString()
        {
            var board = new Board(2, 2);

            var expectedString = "--\n" +
                                 "--";
            Assert.That(board.ToString(), Is.EqualTo(expectedString));
        }
        [Test]
        public void BoardWithDifferentDimensionsShouldResultInCorrectString()
        {
            var board = new Board(4, 3);

            var expectedString = "----\n" +
                                 "----\n" +
                                 "----";
            Assert.That(board.ToString(), Is.EqualTo(expectedString));
        }

        [Test]
        public void RandomizeBoardShouldResultInCallingTheRandomizer()
        {
            var board = new Board(1, 1);

            var randomizer = A.Fake<IRandomizer>();
            board.Randomizer = randomizer;

            board.CreateRandom();

            A.CallTo(() => randomizer.Randomize()).MustHaveHappened();
        }

        [Test]
        public void RandomizeThreeByThreeBoardShouldResultInRandomizedBoard()
        {
            var board = new Board(3, 3);

            var randomizer = A.Fake<IRandomizer>();
            board.Randomizer = randomizer;
            A.CallTo(() => randomizer.Randomize()).ReturnsNextFromSequence(true,false,true,false,true,false,true,false,false);

            board.CreateRandom();

            var expectedString = "+-+\n" +
                                 "-+-\n" +
                                 "+--";
            Assert.That(board.ToString(), Is.EqualTo(expectedString));
        }
    }
}
