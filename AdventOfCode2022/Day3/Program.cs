using Day3;
using Lib;

var input = await FileUtilities.GetSampleAsync(FileUtilities.RealFileName);

// A
var result = Puzzle.Part1(input);
Console.WriteLine(result);