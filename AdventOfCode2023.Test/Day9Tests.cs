namespace AdventOfCode2023.Test;

using AdventOfCode2023.Solvers.Day9;

public class Day9Tests
{
    private const string Data = @"0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45";

    [Fact]
    public void Day1_Part1()
    {
        var solver = new Day9Solver();

        var data = solver.ParseData(Data);

        var result = solver.SolvePart1(data);

        Assert.Equal(142, result);
    }

    [Fact]
    public void Day1_Part2()
    {
        var solver = new Day9Solver();

        var data = solver.ParseData(Data);

        var result = solver.SolvePart2(data);

        Assert.Equal(281, result);
    }
}