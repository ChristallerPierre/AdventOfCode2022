using Day2;
using Lib;

//var filename = "Sample.txt";
var filename = "Real.txt";
var input = await FileUtilities.GetSampleAsync(filename);
var output = Puzzle.Part2(input);
Console.WriteLine($"result: {output}");