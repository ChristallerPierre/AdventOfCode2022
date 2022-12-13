namespace Day4;

public class Puzzle
{
    public static List<string> ParseLine(string line)
        => line.Split(',').ToList();

    public static IEnumerable<int> ParseSection(string section)
    {
        var nbs = section
            .Split('-')
            .Select(s => int.Parse(s))
            .ToList();
        var lowerValue = nbs[0];
        var upperValue = nbs[1];
        var range = Enumerable.Range(lowerValue, upperValue - lowerValue + 1);
        return range;
    }

    public static bool IsOverlapping(IEnumerable<int> sectionA, IEnumerable<int> sectionB)
        => sectionA.Intersect(sectionB).Any();

    public static bool IsContained(IEnumerable<int> sectionA, IEnumerable<int> sectionB)
        => sectionA.Min() <= sectionB.Min() && sectionA.Max() >= sectionB.Max()
            || sectionA.Min() >= sectionB.Min() && sectionA.Max() <= sectionB.Max();


    public static List<IEnumerable<int>> GetSections(string line)
        => ParseLine(line)
            .Select(l => ParseSection(l))
        .ToList();

    public static int Part1(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var sum = 0;
        foreach (var line in lines)
        {
            var sections = GetSections(line);
            if (IsContained(sections[0], sections[1]))
                sum++;
        }
        return sum;
    }

    public static int Part2(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var sum = 0;
        foreach (var line in lines)
        {
            var sections = GetSections(line);
            if (IsOverlapping(sections[0], sections[1]))
                sum++;
        }
        return sum;
    }
}
