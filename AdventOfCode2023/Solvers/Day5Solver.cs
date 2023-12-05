namespace AdventOfCode2023.Solvers;

public record Garden(long[] Seeds, IEnumerable<IEnumerable<(long Destination, long Source, long Range)>> Mappers)
{
    public long Map(long source)
    {
        foreach(var mapper in Mappers)
        {
            foreach(var map in mapper)
            {
                if(source >= map.Source && source < map.Source + map.Range)
                {
                    source = map.Destination + (source - map.Source);
                }
            }
        }     

        return source;   
    }
}

public class Day5Solver : BaseSolver<Garden, long>
{
    public override Garden ParseData(string rawData) {
        var groups = rawData.SplitByBlankLine();

        var seeds = groups[0][(groups[0].IndexOf(':') + 1)..].SplitBy<long>(" ");

        var maps = new List<List<(long Destination, long Source, long Range)>>();

        for(var i = 1; i < groups.Length; i++)
        {
            var group = new List<(long Destination, long Source, long Range)>();

            foreach(var map in groups[i].SplitByNewline<string>().Skip(1))
            {
                var numbers = map.SplitBy<long>(" ");

                group.Add((numbers[0], numbers[1], numbers[2]));
            }

            maps.Add(group);
        }

        return new Garden(seeds, maps);
    }

    public override long SolvePart1(Garden inputData) => inputData.Seeds.Select(inputData.Map).Min();

    public override long SolvePart2(Garden inputData) => 0;
}