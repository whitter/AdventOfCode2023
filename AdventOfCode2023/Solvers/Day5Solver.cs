using System.Data;
using System.Text.Json;
using Microsoft.VisualBasic;

namespace AdventOfCode2023.Solvers.Day5;

public record Garden(long[] Seeds, IEnumerable<IEnumerable<(long From, long To, long Delta)>> Mappers);

public class Day5Solver : BaseSolver<Garden, long>
{
    public override Garden ParseData(string rawData) {
        var groups = rawData.SplitByBlankLine();

        var seeds = groups[0][(groups[0].IndexOf(':') + 1)..].SplitBy<long>(" ");

        var maps = new List<List<(long From, long To, long Delta)>>();

        for(var i = 1; i < groups.Length; i++)
        {
            var group = new List<(long From, long To, long Delta)>();

            foreach(var map in groups[i].SplitByNewline<string>().Skip(1))
            {
                var numbers = map.SplitBy<long>(" ");

                group.Add((numbers[1], numbers[1] + numbers[2] - 1, numbers[0] - numbers[1]));
            }

            maps.Add(group);
        }

        return new Garden(seeds, maps);
    }

    public override long SolvePart1(Garden inputData) 
    {
        var result = long.MaxValue;

        foreach(var seed in inputData.Seeds)
        {
            var current = seed;

            foreach(var mapper in inputData.Mappers)
            {
                foreach(var (From, To, Delta) in mapper)
                {
                    if(current >= From && current <= To)
                    {
                        current += Delta;
                        break;
                    }
                }
            }

            result = Math.Min(result, current);
        }

        return result;
    }

    public override long SolvePart2(Garden inputData)
    {
        var ranges = new List<(long From, long To)>();

        for(var i = 0; i < inputData.Seeds.Length; i += 2)
        {
            ranges.Add((inputData.Seeds[i], inputData.Seeds[i] + inputData.Seeds[i + 1] - 1));
        }

        foreach(var mapper in inputData.Mappers)
        {
            var temp = new List<(long From, long To)>();
            var maps = mapper.OrderBy(x => x.From);

            foreach(var range in ranges)
            {
                var leftovers = range;

                foreach(var (From, To, Delta) in maps)
                {
                    (long From, long To) before = (leftovers.From, Math.Min(leftovers.To, From - 1));
                    (long From, long To) inside = (leftovers.From + Delta, Math.Min(leftovers.To, To) + Delta);

                    if(before.From <= before.To)
                    {
                        temp.Add(before);

                        leftovers.From = From;
                    }

                    if(inside.From <= inside.To)
                    {
                        temp.Add(inside);

                        leftovers.From = To + 1;
                    }

                    if(leftovers.From >= leftovers.To)
                    {
                        break;
                    }
                }

                if(leftovers.From < leftovers.To)
                {
                    temp.Add(leftovers);
                }
            }

            ranges = temp;
        }

        return ranges.Min(x => x.From);
    }
}