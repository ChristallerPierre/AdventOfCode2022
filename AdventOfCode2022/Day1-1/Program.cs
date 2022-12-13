using Day1_1;
using Lib;

var input = await FileUtilities.GetSampleAsync(FileUtilities.RealFileName);
var output = Puzzle.Part2(input, 3);
Console.WriteLine($"result: {output}");