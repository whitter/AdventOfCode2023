using System.Runtime.CompilerServices;

public abstract class BaseSolver<TData, TResult> : ISolver<TData, TResult>
{
    public abstract TData ParseData(string rawData);
    public abstract TResult SolvePart1(TData inputData);
    public abstract TResult SolvePart2(TData inputData);
}