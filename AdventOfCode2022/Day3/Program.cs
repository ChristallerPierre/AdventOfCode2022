using Day3;
using Lib;

string RealFile = "Real.txt";
var input = await FileUtilities.GetSampleAsync(RealFile);

// A
var result = Puzzle.Part1(input);
Console.WriteLine(result);