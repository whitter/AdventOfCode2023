using System.CommandLine;
using System.Diagnostics;

var dayOption = new Option<string>(
    name: "--day",
    description: "The day number of the challange to run");

var rootCommand = new RootCommand("Advent of Code 2023")
{
    dayOption
};

rootCommand.SetHandler(HandleProcess, dayOption);

return await rootCommand.InvokeAsync(args);

void HandleProcess(string day)
{
    var filePath = $"{AppDomain.CurrentDomain.BaseDirectory}Data/day{day}_input.txt";

    string solverClassName = $"AdventOfCode2023.Solvers.Day{day}.Day{day}Solver";
    var solverType = Type.GetType(solverClassName);

    if (solverType == null)
    {
        Console.WriteLine("Invalid day number or solver class not found.");
        return;
    }

    dynamic? solver = Activator.CreateInstance(solverType);

    var rawData = File.ReadAllText(filePath);

    var timer = new Stopwatch();
    timer.Start();

    var part1Data = solver!.ParseData(rawData);
    var part1Result = solver!.SolvePart1(part1Data);

    timer.Stop();

    Console.WriteLine($"Day {day} Part 1 Solution: {part1Result} ({timer.ElapsedMilliseconds}ms)");

    timer.Restart();

    var part2Data = solver!.ParseData(rawData);
    var part2Result = solver!.SolvePart2(part2Data);

    timer.Stop();

    Console.WriteLine($"Day {day} Part 2 Solution: {part2Result} ({timer.ElapsedMilliseconds}ms)");
}
