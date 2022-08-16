using BowlingGame;

namespace BowlingGameTest
{
    public class TestCase
    {
        private readonly Game _game;

        public TestCase()
        {
            _game = new Game();
        }

        [Fact]
        public void TestGutterGame()
        {
            RollMany(20, 0);
            Assert.Equal(0, _game.Score());
        }

        [Fact]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.Equal(20, _game.Score());
        }

        [Fact]
        public void TestOneSpare()
        {
            RollSpare();
            _game.Roll(3);
            RollMany(17, 0);

            Assert.Equal(16, _game.Score());
        }

        [Fact]
        public void TestOneStrike()
        {
            RollStrike();
            _game.Roll(3);
            _game.Roll(4);
            RollMany(16, 0);

            Assert.Equal(24, _game.Score());
        }

        [Fact]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.Equal(300, _game.Score());
        }

        [Fact]
        public void TestRandomGameNoExtraRoll()
        {
            _game.Roll(new[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });
            Assert.Equal(131, _game.Score());
        }

        [Fact]
        public void TestRandomGameWithSpareThenStrikeAtEnd()
        {
            _game.Roll(new[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 });
            Assert.Equal(143, _game.Score());
        }

        [Fact]
        public void TestRandomGameWithThreeStrikesAtEnd()
        {
            _game.Roll(new[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 });
            Assert.Equal(163, _game.Score());
        }

        private void RollMany(int n, int pins)
        {
            for (var i = 0; i < n; i++)
            {
                _game.Roll(pins);
            }
        }

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }

        private void RollStrike()
        {
            _game.Roll(10);
        }
    }
}