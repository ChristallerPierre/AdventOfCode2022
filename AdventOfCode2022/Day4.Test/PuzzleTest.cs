using FluentAssertions;
using Lib;

namespace Day4.Test;

public class PuzzleTest
{
    [Theory]
    [InlineData(FileUtilities.SampleFileName, 2)]
    [InlineData(FileUtilities.RealFileName, 466)]
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
    [InlineData("3-7", new[] { 3, 4, 5, 6, 7 })]
    public void ParseSection(string input, IEnumerable<int> expected)
    {
        // A

        // A
        var result = Puzzle.ParseSection(input);

        // A
        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(new[] { 2, 3, 4, 5, 6, 7, 8 }, new[] { 3, 4, 5, 6, 7 })]
    [InlineData(new[] { 6 }, new[] { 4, 5, 6 })]
    public void IsContained(IEnumerable<int> sectionsA, IEnumerable<int> sectionsB)
    {
        // A

        // A
        var result = Puzzle.IsContained(sectionsA, sectionsB);

        // A
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData(new[] { 5, 6, 7 }, new[] { 7, 8, 9 })]
    [InlineData(new[] { 6 }, new[] { 4, 5, 6 })]
    public void IsOverlapping(IEnumerable<int> sectionsA, IEnumerable<int> sectionsB)
    {
        // A

        // A
        var result = Puzzle.IsOverlapping(sectionsA, sectionsB);

        // A
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData(FileUtilities.SampleFileName, 4)]
    [InlineData(FileUtilities.RealFileName, 865)]
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