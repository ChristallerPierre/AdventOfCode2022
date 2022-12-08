using FluentAssertions;
using Lib;

namespace Day1_1.Test
{
    public class TestPuzzle
    {
        private const string FileSample1 = "Sample1.txt";
        private const string ActualQuestion = "RealInput.txt";

        [Theory]
        [InlineData(FileSample1, 24000)]
        [InlineData(ActualQuestion, 72478)]
        public async Task Part1Solution1(string filename, int expectedAnswer)
        {
            // A
            var input = await FileUtilities.GetSampleAsync(filename);

            // A
            var output = Puzzle.Part1Solution1(input);

            // A
            output.Should().Be(expectedAnswer);
        }

        [Theory]
        [InlineData(FileSample1, 24000)]
        [InlineData(ActualQuestion, 72478)]
        public async Task Part1Solution2(string filename, int expectedAnswer)
        {
            // A
            var input = await FileUtilities.GetSampleAsync(filename);

            // A
            var output = Puzzle.Part1Solution2(input);

            // A
            output.Should().Be(expectedAnswer);
        }

        [Theory]
        [InlineData(FileSample1, 45000, 3)]
        [InlineData(ActualQuestion, 210367, 3)]
        public async Task Part2(string filename, int expectedAnswer, int topNb)
        {
            // A
            var input = await FileUtilities.GetSampleAsync(filename);

            // A
            var output = Puzzle.Part2(input, topNb);

            // A
            output.Should().Be(expectedAnswer);
        }
    }
}