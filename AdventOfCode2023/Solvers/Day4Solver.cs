namespace AdventOfCode2023.Solvers.Day4;

public record Card(int Id, int TotalWins);

public class Day4Solver : BaseSolver<int[], int>
{
    public override int[] ParseData(string rawData) => 
        rawData
            .SplitByNewline<string>()
            .Select(line => {
                var winning = line[(line.IndexOf(':') + 1)..line.IndexOf('|')].SplitBy<string>(" ");
                var scratched = line[(line.IndexOf('|') + 1)..].SplitBy<string>(" ");

                return scratched.Count(winning.Contains);
            })
            .ToArray();

    public override int SolvePart1(int[] inputData) => inputData.Sum(x => x > 0 ? 1 << x - 1 : 0); 

    public override int SolvePart2(int[] inputData)
    {
        int[] counts = Enumerable.Repeat(1, inputData.Length).ToArray();

        for(var i = 0; i < inputData.Length; i++)
        {
            for(var n = 1; n <= inputData[i]; n++)
            {
                counts[n + i] += counts[i];
            }
        }

        return counts.Sum();
    }
}