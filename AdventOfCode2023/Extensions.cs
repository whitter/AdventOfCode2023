namespace AdventOfCode2023;

public static class Extensions
{
    public static T[] SplitByNewline<T>(this string input)
    {
        return input.SplitBy<T>(["\r", "\n", "\r\n"]);
    }

    public static string[] SplitByBlankLine(this string input)
    {
        return input.SplitBy<string>(["\r\r", "\n\n", "\r\n\r\n"]);
    }

    public static T[] SplitBy<T>(this string value, params string[] separators)
    {
        return value
            .Split(separators, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => (T)Convert.ChangeType(x, typeof(T)))
            .ToArray();
    }
}