using FluentAssertions;
using Lib;

namespace Day5.Test
{
    public class PuzzleTest
    {
        private const string InitialPositionFilenameSample = "SamplePosition.txt";
        private const string InstructionsFilenameSample = "SampleInstructions.txt";
        private const string InitialPositionFilenameReal = "RealPosition.txt";
        private const string InstructionsFilenameReal = "RealInstructions.txt";

        [Theory]
        [InlineData(InitialPositionFilenameSample, InstructionsFilenameSample, "CMZ", 3, 4)]
        [InlineData(InitialPositionFilenameReal, InstructionsFilenameReal, "QNHWJVJZW", 9, 4)]
        public async Task Part1(
            string positionFile, 
            string instructionsFile, 
            string expected, 
            int nbRows, 
            int crateDefinitionLength)
        {
            // A
            var positionInput = await FileUtilities.GetSampleAsync(positionFile);
            var instructionsInput = await FileUtilities.GetSampleAsync(instructionsFile);

            // A
            var result = Puzzle.Part1(positionInput, instructionsInput, nbRows, crateDefinitionLength);

            // A
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(InitialPositionFilenameSample, InstructionsFilenameSample, "MCD", 3, 4)]
        [InlineData(InitialPositionFilenameReal, InstructionsFilenameReal, "BPCZJLFJW", 9, 4)]
        public async Task Part2(
            string positionFile,
            string instructionsFile,
            string expected,
            int nbRows,
            int crateDefinitionLength)
        {
            // A
            var positionInput = await FileUtilities.GetSampleAsync(positionFile);
            var instructionsInput = await FileUtilities.GetSampleAsync(instructionsFile);

            // A
            var result = Puzzle.Part2(positionInput, instructionsInput, nbRows, crateDefinitionLength);

            // A
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(InitialPositionFilenameSample)]
        public async Task BuildInitialScenario(string positionFile)
        {
            // A
            var positionInput = await FileUtilities.GetSampleAsync(positionFile);
            var expected = new List<CratePile>()
            {
                new(0){ Crates = {'N', 'Z'}, },
                new(1){ Crates = {'D', 'C', 'M'}, },
                new(2){ Crates = {'P'}, },
            };

            // A
            var result = Puzzle.BuildInitialScenario(positionInput, 3, 4);

            // A
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(InstructionsFilenameSample)]
        public async Task BuildInstructions(string instructionsFile)
        {
            // A
            var instructionsInput = await FileUtilities.GetSampleAsync(instructionsFile);
            var expected = new List<Instruction>()
            {
                new (0){
                    NbMoved = 1,
                    SourcePileIndex = 2,
                    DestinationPileIndex = 1
                },
                new (1){
                    NbMoved = 3,
                    SourcePileIndex = 1,
                    DestinationPileIndex = 3
                },
                new (2){
                    NbMoved = 2,
                    SourcePileIndex = 2,
                    DestinationPileIndex = 1
                },
                new (3){
                    NbMoved = 1,
                    SourcePileIndex = 1,
                    DestinationPileIndex = 2
                },
            };

            // A
            var result = Puzzle.BuildInstructions(instructionsInput);

            // A
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ApplyInstructions()
        {
            // A
            var positions = new SortedSet<CratePile>() {
                new(0){ Crates = {'N', 'Z'}, },
                new(1){ Crates = {'D', 'C', 'M'}, },
                new(2){ Crates = {'P'}, },
            };
            var instructions = new SortedSet<Instruction>()
            {
                new (0){
                    NbMoved = 1,
                    SourcePileIndex = 2,
                    DestinationPileIndex = 1
                },
                new (1){
                    NbMoved = 3,
                    SourcePileIndex = 1,
                    DestinationPileIndex = 3
                },
                new (2){
                    NbMoved = 2,
                    SourcePileIndex = 2,
                    DestinationPileIndex = 1
                },
                new (3){
                    NbMoved = 1,
                    SourcePileIndex = 1,
                    DestinationPileIndex = 2
                },
            };
            var expected = new SortedSet<CratePile>()
            {
                new(0){ Crates = { 'C' }, },
                new(1){ Crates = { 'M' }, },
                new(2){ Crates = { 'Z', 'N', 'D', 'P' }, },
            };

            // A
            var result = Puzzle.ApplyInstructions(positions, instructions, false);

            // A
            result.Should().BeEquivalentTo(expected);
        }
    }
}