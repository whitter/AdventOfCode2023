//if (args.Length == 0)
//{

//    Console.WriteLine("Please provide the day number as a command-line argument.");
//    return;
//}

string dayNumber = "1"; //args[0];
var filePath = "path/to/your/input/file.txt";

string solverClassName = $"Day{dayNumber}Solver";
var solverType = Type.GetType(solverClassName);

if (solverType == null || !typeof(IAdventOfCodeSolver<,>).IsAssignableFrom(solverType))
{
    Console.WriteLine("Invalid day number or solver class not found.");
    return;
}

dynamic? solver = Activator.CreateInstance(solverType);
var inputData = solver!.ParseData(filePath);
var part1Result = solver!.SolvePart1(inputData);
var part2Result = solver!.SolvePart2(inputData);

Console.WriteLine($"Day {dayNumber} Part 1 Solution: {part1Result}");
Console.WriteLine($"Day {dayNumber} Part 2 Solution: {part2Result}");
