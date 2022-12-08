using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class Puzzle
    {
        public static int Part1(string input)
        {
            var lines = input.Split(Environment.NewLine);

            var sum = 0;
            foreach (var sack in lines)
            {
                var item = GetDuplicatedItem(sack);
                var priority = GetTypePriority(item);
                sum += priority;
            }

            return sum;
        }

        public static int GetTypePriority(char letter)
        {
            return letter >= 'a' ?
                letter - 'a' + 1
                : letter - 'A' + 27;
        }

        public static char GetDuplicatedItem(string line)
        {
            var secondPouch = line.Skip(line.Length / 2);
            return line.Intersect(secondPouch).First();
        }

        public static int Part2(string input)
        {
            var lines = input.Split(Environment.NewLine);

            var sum = 0;
            const int groupSize = 3;
            for (int i = 0; i < lines.Length; i += groupSize)
            {
                var groupSacks = lines.Skip(i).Take(groupSize);
                var badge = FindBadge(groupSacks);
                var priority = GetTypePriority(badge);
                sum += priority;
            }
            return sum;
        }

        public static char FindBadge(IEnumerable<string> s)
        {
            var sacks = s.ToList();
            var dupeItems = sacks[0].Intersect(sacks[1]);
            return dupeItems.Intersect(sacks[2]).First();
        }
    }
}
