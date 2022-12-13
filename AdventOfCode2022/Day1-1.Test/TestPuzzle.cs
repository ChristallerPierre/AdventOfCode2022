using FluentAssertions;
using Lib;

namespace Day1_1.Test
{
    public class TestPuzzle
    {
        [Theory]
        [InlineData(FileUtilities.SampleFileName, 24000)]
        [InlineData(FileUtilities.RealFileName, 72478)]
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
        [InlineData(FileUtilities.SampleFileName, 24000)]
        [InlineData(FileUtilities.RealFileName, 72478)]
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
        [InlineData(FileUtilities.SampleFileName, 45000, 3)]
        [InlineData(FileUtilities.RealFileName, 210367, 3)]
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