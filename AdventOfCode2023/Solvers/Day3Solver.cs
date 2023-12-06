using System.Text.RegularExpressions;

namespace AdventOfCode2023.Solvers.Day3;

public record Part(int Number, (int y, int x)? Position);

static partial class Extensions
{    
    public static IEnumerable<Part> ToParts(this string[] values)
    {
        for(var i = 0; i < values.Length; i++)
        {
            var matches = FindNumberRegex().Matches(values[i]).AsQueryable();
            
            foreach(var match in matches)
            {
                for(var y = i - 1; y <= i + 1; y++ )
                {
                    for(var x = match.Index - 1; x <= match.Index + match.Length; x ++)
                    {
                        if(y < 0 || y >= values.Length || x < 0 || x >= values[i].Length)
                        {
                            continue;
                        }

                        if(char.IsDigit(values[y][x]) || values[y][x] == '.')
                        {
                            continue;
                        }

                        yield return new Part(int.Parse(match.Value), values[y][x] == '*' ? (y, x) : null);
                    }
                }
            }
        }    
    }

    [GeneratedRegex(@"(\d+)")]
    private static partial Regex FindNumberRegex();
}

public class Day3Solver : BaseSolver<IEnumerable<Part>, int>
{
    public override IEnumerable<Part> ParseData(string rawData) => rawData.SplitByNewline<string>().ToParts();    

    public override int SolvePart1(IEnumerable<Part> inputData) => inputData.Sum(x => x.Number);

    public override int SolvePart2(IEnumerable<Part> inputData) =>
        inputData
            .GroupBy(x => x.Position)
            .Where(x => x.Count() == 2)
            .Sum(x => x.First().Number * x.Last().Number);
}