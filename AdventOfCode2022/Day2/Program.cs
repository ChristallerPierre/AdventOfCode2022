using Day2;
using Lib;

var input = await FileUtilities.GetSampleAsync(FileUtilities.RealFileName);
var output = Puzzle.Part2(input);
Console.WriteLine($"result: {output}");