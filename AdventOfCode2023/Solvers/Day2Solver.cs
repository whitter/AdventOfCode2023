using System.Reflection.Metadata;

namespace AdventOfCode2023.Solvers;

public record Cube(string Color, int Count);

public class Day2Solver : BaseSolver<Dictionary<int, IEnumerable<Cube>>, int>
{
    public override Dictionary<int, IEnumerable<Cube>> ParseData(string rawData) => 
        rawData.SplitByNewline<string>()
            .Select(line => {
                var game = line.Split(':');

                var key = int.Parse(game[0].Split(' ')[1]);
                var value = game[1]
                    .Split([',', ';'])
                    .Select(cube => {
                        var set = cube.Trim().Split(' ');

                        return new Cube(set[1], int.Parse(set[0]));
                    })
                    .OrderByDescending(x => x.Count)
                    .GroupBy(cube => cube.Color)
                    .Select(cubes => cubes.First());

                return new KeyValuePair<int, IEnumerable<Cube>>(key, value);
            })
            .ToDictionary();

    public override int SolvePart1(Dictionary<int, IEnumerable<Cube>> inputData)
    {
        var bounds = new Dictionary<string, int> {
            { "red", 12},
            { "green", 13},
            { "blue", 14},
        };

        return inputData
            .Where(game => !game.Value.Any(set => set.Count > bounds[set.Color]))
            .Sum(game => game.Key);
    }

    public override int SolvePart2(Dictionary<int, IEnumerable<Cube>> inputData) => 
        inputData.Sum(x => x.Value.Aggregate(1, (power, set) => power * set.Count));
}