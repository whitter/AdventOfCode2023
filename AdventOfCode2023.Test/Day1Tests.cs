namespace AdventOfCode2023.Test;

public class Day1Tests
{
    [Fact]
    public void Day1_Part1()
    {
        var solver = new Day1Solver();

        var data = solver.ParseData(@"1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet");

        var result = solver.SolvePart1(data);

        Assert.Equal(142, result);
    }

    [Fact]
    public void Day1_Part2()
    {
        var solver = new Day1Solver();

        var data = solver.ParseData(@"two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen");

        var result = solver.SolvePart2(data);

        Assert.Equal(281, result);
    }
}