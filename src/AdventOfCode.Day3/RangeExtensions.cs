namespace AdventOfCode.Day3;

public static class RangeExtensions
{
    public static bool OverlapsWith(this Range range1, Range range2)
    {
        return range1.Start.Value <= range2.End.Value && range1.End.Value >= range2.Start.Value;
    }
}