namespace AdventOfCode2023.Solvers;

public class Day1Solver : BaseSolver<string[], int>
{
    public override string[] ParseData(string rawData)
    {
        return rawData.SplitByNewline<string>();
    }

    public override int SolvePart1(string[] inputData)
    {
        return inputData.Sum(x => int.Parse($"{x.First(char.IsNumber)}{x.Last(char.IsNumber)}"));
    }

    public override int SolvePart2(string[] inputData)
    {
        return inputData.Sum(ParseLines);
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

    private int ParseLines(string line)
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

        return int.Parse($"{values.First()}{values.Last()}");
    }
}