namespace AdventOfCode2023.Test;

using AdventOfCode2023.Solvers.Day3;

public class Day3Tests
{
    private const string Data = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..";

    [Fact]
    public void Day3_Part1()
    {
        var solver = new Day3Solver();

        var data = solver.ParseData(Data);

        var result = solver.SolvePart1(data);

        Assert.Equal(4361, result);
    }

    [Fact]
    public void Day3_Part2()
    {
        var solver = new Day3Solver();

        var data = solver.ParseData(Data);

        var result = solver.SolvePart2(data);

        Assert.Equal(467835, result);
    }
}