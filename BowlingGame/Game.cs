﻿namespace BowlingGame
{
    public class Game
    {
        private readonly int[] _rolls = new int[21];
        private int _currentRoll;

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        public void Roll(IEnumerable<int> pins)
        {
            foreach (var pin in pins)
            {
                _rolls[_currentRoll++] = pin;
            }
        }

        public int Score()
        {
            var score = 0;
            var frameIndex = 0;

            for (var frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }
            }

            return score;
        }

        private int SumOfBallsInFrame(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1];
        }

        private int SpareBonus(int frameIndex)
        {
            return _rolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
        }

        private bool IsSpare(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;
        }

        private bool IsStrike(int frameIndex)
        {
            return _rolls[frameIndex] == 10;
        }
    }
}
