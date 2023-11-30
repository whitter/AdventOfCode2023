internal interface IAdventOfCodeSolver<TData, TResult>
{
    TData ParseData(string filePath);
    TResult SolvePart1(TData inputData);
    TResult SolvePart2(TData inputData);
}