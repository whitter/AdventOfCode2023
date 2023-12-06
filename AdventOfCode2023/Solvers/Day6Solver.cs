namespace AdventOfCode2023.Solvers.Day6;

public class Day6Solver : BaseSolver<int[][], long>
{
    public override int[][] ParseData(string rawData) => rawData.SplitByNewline<string>()
        .Select(line => line[(line.IndexOf(":") + 1)..].SplitBy<int>(" ")).ToArray();

    private long CalculateCount(long time, long distance)
    {
        var speed1 = 0L;
        var speed2 = 0L;

        for(var speed = 1; speed <= time; speed++)
        {
            if(IsFaster(distance, speed, time))
            {
                speed1 = speed;
                break;
            }
        }

        for(var speed = time; speed >= 0; speed--)
        {
            if(IsFaster(distance, speed, time))
            {
                speed2 = speed;
                break;
            }
        }

        return speed2 - speed1 + 1;
    }

    private static bool IsFaster(long distance, long speed, long time)
    {
        var distance2 = speed * (time - speed);

        if(distance2 > distance)
        {
            return true;
        }

        return false;
    }

    public override long SolvePart1(int[][] inputData)
    {
        var results = new List<long>();

        for(var race = 0; race < inputData[0].Length; race++)
        {
            var fastest = new List<int>();

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