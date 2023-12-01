public class Day1Solver : BaseSolver<string[], int>
{
    public override string[] ParseData(string rawData)
    {
        return rawData.SplitByNewline<string>();
    }

    public override int SolvePart1(string[] inputData)
    {
        return inputData.Select(x => int.Parse($"{x.First(char.IsNumber)}{x.Last(char.IsNumber)}")).Sum();
    }

    private Dictionary<string, char> DigitWords = new()
    {
        { "one", '1' },
        { "two", '2' },
        { "three", '3' },
        { "four", '4' },
        { "five", '5' },
        { "six", '6' },
        { "seven", '7' },
        { "eight", '8' },
        { "nine", '9' }
    };

    public override int SolvePart2(string[] inputData)
    {
        List<int> results = [];

        foreach(var line in inputData)
        {
            List<char> values = [];

            for(var i = 0; i < line.Length; i++)
            {
                if(char.IsNumber(line[i]))
                {
                    values.Add(line[i]);
                    continue;
                }

                foreach(var (word, digit) in DigitWords)
                {
                    if(i + word.Length - 1 >= line.Length || line[i..(i + word.Length)] != word)
                    {
                        continue;
                    }

                    values.Add(digit);
                }
            }

            results.Add(int.Parse($"{values.First()}{values.Last()}"));
        }

        return results.Sum();
    }
}