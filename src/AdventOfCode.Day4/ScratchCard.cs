using AdventOfCode.Common;

namespace AdventOfCode.Day4;

public class ScratchCard
{
    public required int Id { get; init; }
    public required int[] WinningNumbers { get; init; }
    public required int[] EnteredNumbers { get; init; }

    public int MatchingNumberCount => WinningNumbers.Intersect(EnteredNumbers).Count();
    public int Score => MatchingNumberCount > 0 ? (int)Math.Pow(2, MatchingNumberCount - 1) : 0;

    public static ScratchCard Parse(string line)
    {
        var scratchCardSplit = line.Split(": ", count: 2);
        var scratchCardId = int.Parse(scratchCardSplit[0][5..]);

        var (winningNumbersString, enteredNumbersString) = scratchCardSplit[1].Split(" | ", 2);
        var winningNumbers = winningNumbersString.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToArray();
        var enteredNumbers = enteredNumbersString.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToArray();

        return new ScratchCard
        {
            Id = scratchCardId,
            WinningNumbers = winningNumbers,
            EnteredNumbers = enteredNumbers
        };
    }
}