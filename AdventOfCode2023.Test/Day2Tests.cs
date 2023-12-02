namespace AdventOfCode2023.Test;

using AdventOfCode2023.Solvers;

public class Day2Tests
{
    private const string Data = @"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";

    [Fact]
    public void Day2_Part1()
    {
        var solver = new Day2Solver();

        var data = solver.ParseData(Data);

        var result = solver.SolvePart1(data);

        Assert.Equal(8, result);
    }

    [Fact]
    public void Day2_Part2()
    {
        var solver = new Day2Solver();

        var data = solver.ParseData(Data);

        var result = solver.SolvePart2(data);

        Assert.Equal(2286, result);
    }
}