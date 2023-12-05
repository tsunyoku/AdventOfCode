namespace AdventOfCode.Day3;

public class Number
{
    public required int StartIndex { get; init; }
    public required int EndIndex { get; init; }
    public required int Value { get; init; }
    public int Length => EndIndex - StartIndex + 1;
}