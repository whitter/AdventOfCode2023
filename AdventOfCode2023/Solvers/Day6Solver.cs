namespace AdventOfCode2023.Solvers.Day6;

public class Day6Solver : BaseSolver<int[][], long>
{
    public override int[][] ParseData(string rawData) => rawData.SplitByNewline<string>()
        .Select(line => line[(line.IndexOf(':') + 1)..].SplitBy<int>(" ")).ToArray();

    private static long CalculateCount(long time, long distance)
    {
        var min = 0L;
        var max = 0L;

        for(var speed = 1; speed <= time; speed++)
        {
            if(IsFaster(distance, speed, time))
            {
                min = speed;
                break;
            }
        }

        for(var speed = time; speed >= 0; speed--)
        {
            if(IsFaster(distance, speed, time))
            {
                max = speed;
                break;
            }
        }

        return max - min + 1;
    }

    private static bool IsFaster(long distance, long speed, long time)
    {
        var distance2 = speed * (time - speed);

        return distance2 > distance;
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