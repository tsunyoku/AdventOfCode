namespace AdventOfCode.Common;

public static class ListExtensions
{
    public static void Deconstruct<T>(this IList<T> list, out T first, out T second)
    {

        first = list.Count > 0 ? list[0] : throw new InvalidOperationException();
        second = list.Count >= 2 ? list[1] : throw new InvalidOperationException();
    }
}