using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode2023.Solvers;

public class Cube {
    public string Color { get; set; } = null!;
    public int Count { get; set;}
}

public class Day2Solver : BaseSolver<Dictionary<int, IEnumerable<Cube>>, int>
{
    public override Dictionary<int, IEnumerable<Cube>> ParseData(string rawData) => 
        rawData.SplitByNewline<string>()
            .Select(line => {
                var game = line.Split(':');

                var key = int.Parse(game[0].Split(' ')[1]);
                var value = game[1]
                    .Replace(";", ",")
                    .Split(',')
                    .Select(cube => {
                        var set = cube.Trim().Split(' ');

                        return new Cube { Color = set[1], Count = int.Parse(set[0]) };
                    });

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

    public override int SolvePart2(Dictionary<int, IEnumerable<Cube>> inputData) => inputData
        .Sum(PowerOfMaxCubes);

    private int PowerOfMaxCubes(KeyValuePair<int, IEnumerable<Cube>> game) =>
        game.Value
            .GroupBy(cube => cube.Color)
            .Select(cube => cube.Max(x => x.Count))
            .Aggregate(1, (power, count) => power * count);
}