using System.CommandLine;
using System.Reflection;

var dayOption = new Option<string>(
    name: "--day",
    description: "The file to read and display on the console.");

var partOption = new Option<string>(
    name: "--part",
    description: "The file to read and display on the console.");

var rootCommand = new RootCommand("Sample app for System.CommandLine")
{
    dayOption,
    partOption
};

rootCommand.SetHandler(HandleProcess, dayOption, partOption);

return await rootCommand.InvokeAsync(args);

void HandleProcess(string day, string part)
{
    var filePath = $"{AppDomain.CurrentDomain.BaseDirectory}Data/day{day}_input.txt";

    string solverClassName = $"Day{day}Solver";
    var solverType = Type.GetType(solverClassName);

    if (solverType == null)
    {
        Console.WriteLine("Invalid day number or solver class not found.");
        return;
    }

    dynamic? solver = Activator.CreateInstance(solverType);

    var rawData = File.ReadAllText(filePath);
    var inputData = solver!.ParseData(rawData);

    dynamic result;

    result = part switch {
        "1" => solver!.SolvePart1(inputData),
        "2" => solver!.SolvePart2(inputData),
        _ => new ArgumentException("Part invalid")
    };

    Console.WriteLine($"Day {day} Part {part} Solution: {result}");
}
