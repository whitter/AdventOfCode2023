namespace AdventOfCode2023.Test;

using AdventOfCode2023.Solvers.Day6;

public class Day6Tests
{
    private const string Data = @"Time:      7  15   30
Distance:  9  40  200";

    [Fact]
    public void Day5_Part1()
    {
        var solver = new Day6Solver();

        var data = solver.ParseData(Data);

        var result = solver.SolvePart1(data);

        Assert.Equal(288, result);
    }

    [Fact]
    public void Day5_Part2()
    {
        var solver = new Day6Solver();

        var data = solver.ParseData(Data);

        var result = solver.SolvePart2(data);

        Assert.Equal(71503, result);
    }
}