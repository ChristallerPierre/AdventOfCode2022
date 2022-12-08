using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public enum HintOpponent
    {
        Rock = 'A',
        Paper = 'B',
        Scissors = 'C',
    }

    public enum HintMine
    {
        Rock = 'X',
        Paper = 'Y',
        Scissors = 'Z',
    }

    public enum HintStrategy
    {
        Lose = 'X',
        Draw = 'Y',
        Win = 'Z',
    }

    public class HintParser
    {
        public static T ParseHint<T>(char input) where T : struct
        {
            return (T)Enum.ToObject(typeof(T), (int)input);
        }
    }
}
