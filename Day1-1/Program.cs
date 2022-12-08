using Day1_1;
using Lib;

//var filename = "Sample1.txt";
var filename = "RealInput.txt";
var input = await FileUtilities.GetSampleAsync(filename);
var output = Puzzle.Part2(input, 3);
Console.WriteLine($"result: {output}");