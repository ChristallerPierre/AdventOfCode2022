namespace Day2
{
    public enum Result
    {
        Lost = 0,
        Draw = 3,
        Won = 6,
    }

    public class ScoreCalculator
    {
        public static Result CalculateResult(HintMine mine, HintOpponent opponent)
        {
            var result = Tuple.Create(mine, opponent) switch
            {
                { Item1: HintMine.Scissors, Item2: HintOpponent.Scissors } => Result.Draw,
                { Item1: HintMine.Scissors, Item2: HintOpponent.Rock } => Result.Lost,
                { Item1: HintMine.Scissors, Item2: HintOpponent.Paper } => Result.Won,
                { Item1: HintMine.Paper, Item2: HintOpponent.Scissors } => Result.Lost,
                { Item1: HintMine.Paper, Item2: HintOpponent.Rock } => Result.Won,
                { Item1: HintMine.Paper, Item2: HintOpponent.Paper } => Result.Draw,
                { Item1: HintMine.Rock, Item2: HintOpponent.Scissors } => Result.Won,
                { Item1: HintMine.Rock, Item2: HintOpponent.Rock } => Result.Draw,
                { Item1: HintMine.Rock, Item2: HintOpponent.Paper } => Result.Lost,
            };
            return result;
        }

        public static int GetScoreForShape(HintMine shape)
        {
            return shape switch
            {
                HintMine.Rock => 1,
                HintMine.Paper => 2,
                HintMine.Scissors => 3,
            };
        }

        public static int CalculateScore(int myShapeScore, Result result)
        {
            return myShapeScore + (int)result;
        }
    }
}
