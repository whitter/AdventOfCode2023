namespace AdventOfCode2023.Solvers;

public class Day1Solver : BaseSolver<string[], int>
{
    public override string[] ParseData(string rawData) => rawData.SplitByNewline<string>();

    public override int SolvePart1(string[] inputData) => inputData.Sum(ParseNumber);

    public override int SolvePart2(string[] inputData) => inputData.Sum(ParseLines);

    private int ParseLines(string line)
    {
        line = line
            .Replace("one", "o1e")
            .Replace("two", "t2o")
            .Replace("three", "t3e")
            .Replace("four", "f4r")
            .Replace("five", "f5e")
            .Replace("six", "s6x")
            .Replace("seven", "s7n")
            .Replace("eight", "e8t")
            .Replace("nine", "n9e");

        return ParseNumber(line);
    }

    private int ParseNumber(string line) => int.Parse($"{line.First(char.IsDigit)}{line.Last(char.IsNumber)}");
}