namespace AdventOfCode2023.Test;

using AdventOfCode2023.Solvers;

public class Day5Tests
{
    private const string Data = @"seeds: 14

seed-to-soil map:
50 98 2
52 50 48

soil-to-fertilizer map:
0 15 37
37 52 2
39 0 15

fertilizer-to-water map:
49 53 8
0 11 42
42 0 7
57 7 4

water-to-light map:
88 18 7
18 25 70

light-to-temperature map:
45 77 23
81 45 19
68 64 13

temperature-to-humidity map:
0 69 1
1 0 69

humidity-to-location map:
60 56 37
56 93 4";

    [Fact]
    public void Day5_Part1()
    {
        var solver = new Day5Solver();

        var data = solver.ParseData(Data);

        var result = solver.SolvePart1(data);

        Assert.Equal(35, result);
    }

    [Fact]
    public void Day5_Part2()
    {
        var solver = new Day5Solver();

        var data = solver.ParseData(Data);

        var result = solver.SolvePart2(data);

        Assert.Equal(30, result);
    }
}