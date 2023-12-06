namespace AdventOfCode2023.Solvers.Day6;

public class Day6Solver : BaseSolver<int[][], long>
{
    public override int[][] ParseData(string rawData) => rawData.SplitByNewline<string>()
        .Select(line => line[(line.IndexOf(':') + 1)..].SplitBy<int>(" ")).ToArray();

    private static long CalculateCount(long time, long distance)
    {
        var a = 1;
        var b = -time;
        var c = distance;

        var discriminant = b * b - 4 * a * c;

        var min = (long)(-b - (-b + Math.Sqrt(discriminant)) / (2 * a) + 1);

        return time - (min * 2) + 1;
    }

    public override long SolvePart1(int[][] inputData)
    {
        var results = new List<long>();

        for(var race = 0; race < inputData[0].Length; race++)
        {
            var fastest = new List<long>();

            var time = inputData[0][race];
            var distance = inputData[1][race];

            results.Add(CalculateCount(time, distance));
        }

        return results.Aggregate(1L, (total, count) => total * count);
    }

    public override long SolvePart2(int[][] inputData)
    {
        var time = long.Parse(inputData[0].Aggregate("", (result, input) => result + input));
        var distance = long.Parse(inputData[1].Aggregate("", (result, input) => result + input));

        return CalculateCount(time, distance);
    }
}