using FluentAssertions;
using Lib;

namespace Day3.Test
{
    public class PuzzleTest
    {
        [Theory]
        [InlineData(FileUtilities.SampleFileName, 157)]
        [InlineData(FileUtilities.RealFileName, 7742)]
        public async Task Part1(string filename, int expected)
        {
            // A
            var input = await FileUtilities.GetSampleAsync(filename);

            // A
            var result = Puzzle.Part1(input);

            // A
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData('a', 1)]
        [InlineData('b', 2)]
        [InlineData('z', 26)]
        [InlineData('A', 27)]
        [InlineData('B', 28)]
        [InlineData('Z', 52)]
        public void GetTypePriority(char letter, int expected)
        {
            // A

            // A
            var result = Puzzle.GetTypePriority(letter);

            // A
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 'p')]
        [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 'L')]
        [InlineData("PmmdzqPrVvPwwTWBwg", 'P')]
        [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 'v')]
        [InlineData("ttgJtRGJQctTZtZT", 't')]
        [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", 's')]
        public void GetDuplicatedItem(string line, char expected)
        {
            // A

            // A
            var result = Puzzle.GetDuplicatedItem(line);

            // A
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(new[] { "vJrwpWtwJgWrhcsFMMfFFhFp", "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "PmmdzqPrVvPwwTWBwg" }, 'r')]
        [InlineData(new[] { "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "ttgJtRGJQctTZtZT", "CrZsJsPPZsGzwwsLwLmpwMDw" }, 'Z')]
        public void FindBadge(string[] lines, char expected)
        {
            // A

            // A
            var result = Puzzle.FindBadge(lines);

            // A
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(FileUtilities.SampleFileName, 70)]
        [InlineData(FileUtilities.RealFileName, 2276)]
        public async Task Part2(string filename, int expected)
        {
            // A
            var input = await FileUtilities.GetSampleAsync(filename);

            // A
            var result = Puzzle.Part2(input);

            // A
            result.Should().Be(expected);
        }
    }
}