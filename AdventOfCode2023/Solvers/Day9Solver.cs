namespace AdventOfCode2023.Solvers.Day9;

public class Day9Solver : BaseSolver<IEnumerable<long[]>, long>
{
    public override IEnumerable<long[]> ParseData(string rawData) => rawData.SplitByNewline<string>().Select(line => line.SplitBy<long>(" "));

    private long Calculate(long[] input)
    {
        input.Skip(1).Zip(input, (long first, long second) => first - second);

        return 0;
    }

    public override long SolvePart1(IEnumerable<long[]> inputData) => inputData.Select(Calculate).Sum();

    public override long SolvePart2(IEnumerable<long[]> inputData) => 0;
}