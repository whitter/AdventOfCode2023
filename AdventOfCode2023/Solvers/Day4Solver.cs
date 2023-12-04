namespace AdventOfCode2023.Solvers;

public record Card(int Id, int TotalWins);

public class Day4Solver : BaseSolver<IEnumerable<Card>, int>
{
    public override IEnumerable<Card> ParseData(string rawData) => 
        rawData
            .SplitByNewline<string>()
            .Select(line => {
                var card = line.Split([':', '|']);

                var id = int.Parse(card[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);

                var winning = card[1].Trim().SplitBy<int>(" ");
                var scratched = card[2].Trim().SplitBy<int>(" ");

                return new Card(id, scratched.Count(winning.Contains));
            });

    public override int SolvePart1(IEnumerable<Card> inputData) => inputData.Sum(x => (int)Math.Pow(2, x.TotalWins - 1));

    public override int SolvePart2(IEnumerable<Card> inputData)
    {
        int copies = 0;

        var cards = inputData.ToDictionary(x => x.Id);

        var queue = new Queue<Card>(inputData);

        while(queue.TryDequeue(out var card))
        {
            copies++;

            for(var i = 1; i <= card.TotalWins; i++)
            {
                queue.Enqueue(cards[card.Id + i]);
            }
        }

        return copies;
    }
}