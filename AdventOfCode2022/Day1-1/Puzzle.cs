using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_1
{
    public class Puzzle
    {
        public static int Part1Solution1(string input)
        {
            var lines = input.Split(Environment.NewLine);
            var groups = MakeGroups(lines);
            var result = groups.Max(g => g.GetTotal());
            return result;
        }

        public static int Part1Solution2(string input)
        {
            var sums = ParseInput(input);
            var result = sums.Max();
            return result;
        }

        public static int Part2(string input, int topNb)
        {
            var sums = ParseInput(input);
            var result = GetSumValue(sums, topNb);
            return result;
        }

        private static List<int> ParseInput(string input)
        {
            const int codeEmptyLine = 0;
            var sums = new List<int>();
            var lastSum = input.Split(Environment.NewLine)
                .Select(line =>
                {
                    var success = int.TryParse(line, out var value);
                    if (!success)
                        return codeEmptyLine;
                    return value;
                })
                .Aggregate((sum, value) =>
                {
                    if (value == codeEmptyLine)
                    {
                        sums.Add(sum);
                        return 0;
                    }
                    else
                        return sum + value;
                });
            sums.Add(lastSum);
            return sums;
        }

        public static List<Group> MakeGroups(string[] lines)
        {
            var groups = new List<Group>();
            var currentGroup = new Group();
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];

                // empty line or last line
                if (line == string.Empty || i + 1 == lines.Length)
                {
                    groups.Add(currentGroup);
                    currentGroup = new Group();
                }
                else
                {
                    var value = int.Parse(line);
                    currentGroup.Values.Add(value);
                }
            }
            return groups;
        }

        public static int GetSumValue(List<int> sums, int topNb)
        {
            return sums
                .OrderByDescending(s => s)
                .Take(topNb)
                .Sum();
        }
    }
}
