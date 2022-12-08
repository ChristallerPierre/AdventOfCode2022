using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Puzzle
    {
        public static int Part1(string input)
        {
            return Solve(input, true);
        }

        public static int Part2(string input)
        {
            return Solve(input, false);
        }

        public static int Solve(string input, bool easyMode)
        {
            var lines = input.Split(Environment.NewLine);
            return lines.Sum(line => GetScoreForRound(line, easyMode));
        }

        public static int GetScoreForRound(string line, bool easyMode)
        {
            var chars = line.Split(' ').Select(c => c.First()).ToList();
            var shapeOpponent = HintParser.ParseHint<HintOpponent>(chars[0]);
            var shapeMine = ParseStrategy(chars[1], easyMode, shapeOpponent);

            var result = ScoreCalculator.CalculateResult(shapeMine, shapeOpponent);
            var scoreForShape = ScoreCalculator.GetScoreForShape(shapeMine);
            var score = ScoreCalculator.CalculateScore(scoreForShape, result);
            return score;
        }

        public static HintMine ParseStrategy(char input, bool easyMode, HintOpponent opponent)
        {
            if (easyMode)
                return HintParser.ParseHint<HintMine>(input);

            var strategy = HintParser.ParseHint<HintStrategy>(input);
            var result = Tuple.Create(strategy, opponent) switch
            {
                { Item1: HintStrategy.Draw } => GetCorrespondingValue(opponent),
                { Item1: HintStrategy.Win, Item2: HintOpponent.Scissors } => HintMine.Rock,
                { Item1: HintStrategy.Win, Item2: HintOpponent.Paper } => HintMine.Scissors,
                { Item1: HintStrategy.Win, Item2: HintOpponent.Rock } => HintMine.Paper,
                { Item1: HintStrategy.Lose, Item2: HintOpponent.Scissors } => HintMine.Paper,
                { Item1: HintStrategy.Lose, Item2: HintOpponent.Paper } => HintMine.Rock,
                { Item1: HintStrategy.Lose, Item2: HintOpponent.Rock } => HintMine.Scissors,
            };
            return result;
        }

        public static HintMine GetCorrespondingValue(HintOpponent opponent)
            => opponent switch
            {
                HintOpponent.Scissors => HintMine.Scissors,
                HintOpponent.Paper => HintMine.Paper,
                HintOpponent.Rock => HintMine.Rock,
            };
    }
}
