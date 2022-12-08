using FluentAssertions;
using Lib;

namespace Day2.Test
{
    public class PuzzleTest
    {
        private const string SampleFile = "Sample.txt";
        private const string RealFile= "Real.txt";

        [Theory]
        [InlineData(SampleFile, 15)]
        [InlineData(RealFile, 14375)]
        public async Task Part1(string filename, int expectedAnswer)
        {
            // A
            var input = await FileUtilities.GetSampleAsync(filename);

            // A
            var output = Puzzle.Part1(input);

            // A
            output.Should().Be(expectedAnswer);
        }

        [Theory]
        [InlineData(SampleFile, 12)]
        [InlineData(RealFile, 10274)]
        public async Task Part2(string filename, int expectedAnswer)
        {
            // A
            var input = await FileUtilities.GetSampleAsync(filename);

            // A
            var output = Puzzle.Part2(input);

            // A
            output.Should().Be(expectedAnswer);
        }

        [Theory]
        [InlineData(HintStrategy.Lose, HintOpponent.Scissors, HintMine.Paper)]
        [InlineData(HintStrategy.Lose, HintOpponent.Rock, HintMine.Scissors)]
        [InlineData(HintStrategy.Lose, HintOpponent.Paper, HintMine.Rock)]
        [InlineData(HintStrategy.Draw, HintOpponent.Scissors, HintMine.Scissors)]
        [InlineData(HintStrategy.Draw, HintOpponent.Rock, HintMine.Rock)]
        [InlineData(HintStrategy.Draw, HintOpponent.Paper, HintMine.Paper)]
        [InlineData(HintStrategy.Win, HintOpponent.Scissors, HintMine.Rock)]
        [InlineData(HintStrategy.Win, HintOpponent.Rock, HintMine.Paper)]
        [InlineData(HintStrategy.Win, HintOpponent.Paper, HintMine.Scissors)]
        public void ParseStrategy(HintStrategy input, HintOpponent opponent, HintMine expected)
        {
            // A

            // A
            var output = Puzzle.ParseStrategy((char)input, false, opponent);

            // A
            output.Should().Be(expected);
        }
    }
}