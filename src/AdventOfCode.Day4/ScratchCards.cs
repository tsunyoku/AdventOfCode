using System.Collections;
using AdventOfCode.Common;

namespace AdventOfCode.Day4;

public class ScratchCards : IPuzzle<int>
{
    public int SolveFirstPuzzle(string input)
    {
        var lines = input.Split("\r\n");
        var cards = lines.Select(ScratchCard.Parse).ToList();
        return cards.Select(x => x.Score).Sum();
    }

    public int SolveSecondPuzzle(string input)
    {
        var lines = input.Split("\r\n");
        var cards = lines.Select(ScratchCard.Parse).ToList();

        var cardCounts = cards.Select(_ => 1).ToArray();

        for (var i = 0; i < cards.Count; i++)
        {
            var card = cards[i];
            var cardCount = cardCounts[i];

            for (var j = 0; j < card.MatchingNumberCount; j++)
            {
                cardCounts[i + j + 1] += cardCount;
            }
        }

        return cardCounts.Sum();
    }
}

internal static class Extensions
{
    public static IEnumerator<int> GetEnumerator(this Range range)
    {
        var start = range.Start.GetOffset(int.MaxValue);
        var end = range.End.GetOffset(int.MaxValue);
        var acc = end.CompareTo(start);
        var current = start;

        do
        {
            yield return current;
            current += acc;
        } while (current != end);
    }
}