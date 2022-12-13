namespace Day5;

public static class Puzzle
{
    public static string Part1(
        string filePosition,
        string fileInstructions,
        int nbRows,
        int crateDefinitionLength)
        => Do(filePosition, fileInstructions, nbRows, crateDefinitionLength, true);

    public static string Part2(
        string filePosition,
        string fileInstructions,
        int nbRows,
        int crateDefinitionLength)
        => Do(filePosition, fileInstructions, nbRows, crateDefinitionLength, false);

    public static string Do(string filePosition,
        string fileInstructions,
        int nbRows,
        int crateDefinitionLength,
        bool reverseOrder)
    {
        var positions = BuildInitialScenario(filePosition, nbRows, crateDefinitionLength);
        var instructions = BuildInstructions(fileInstructions);
        var result = ApplyInstructions(positions, instructions, reverseOrder);
        return new string(
            result.Select(pile => pile.Crates.First())
                .ToArray());
    }

    public static SortedSet<CratePile> BuildInitialScenario(string positionInput, int nbRows, int crateDefinitionLength)
    {
        var cratePiles = new SortedSet<CratePile>();

        for (int i = 0; i < nbRows; i++)
            _ = cratePiles.Add(new CratePile(i));

        var lines = positionInput.Split(Environment.NewLine);
        foreach (var line in lines)
        {
            if (char.IsNumber(line[1]))
                break;

            for (int i = 0; i < nbRows; i++)
            {
                var crate = line.Skip(crateDefinitionLength * i).Take(crateDefinitionLength);
                var crateString = new string(crate.ToArray());
                if (string.IsNullOrWhiteSpace(crateString))
                    continue;
                var c = crate.Skip(1).First();
                cratePiles.ElementAt(i).Crates.Add(c);
            }
        }
        return cratePiles;
    }

    public static SortedSet<Instruction> BuildInstructions(string instructionsInput)
    {
        var instructions = new SortedSet<Instruction>();
        var lines = instructionsInput.Split(Environment.NewLine);
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            if (string.IsNullOrWhiteSpace(line))
                break;

            var parts = line.Split(' ');
            var instruction = new Instruction(i)
            {
                NbMoved = int.Parse(parts[1]),
                SourcePileIndex = int.Parse(parts[3]),
                DestinationPileIndex = int.Parse(parts[5]),
            };
            instructions.Add(instruction);
        }
        return instructions;
    }

    public static SortedSet<CratePile> ApplyInstructions(SortedSet<CratePile> cratePiles, SortedSet<Instruction> instructions, bool reverseOrder)
    {
        foreach (var instruction in instructions)
        {
            var cratesMoved = cratePiles
                .ElementAt(instruction.SourcePileIndex - 1)
                .Crates
                .Take(instruction.NbMoved);
            if (reverseOrder)
                cratesMoved = cratesMoved.Reverse();

            cratePiles
                .ElementAt(instruction.DestinationPileIndex - 1)
                .Crates
                .InsertRange(0, cratesMoved);
            cratePiles
                .ElementAt(instruction.SourcePileIndex - 1)
                .Crates
                .RemoveRange(0, instruction.NbMoved);
        }
        return cratePiles;
    }
}
