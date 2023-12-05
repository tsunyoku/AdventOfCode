using AdventOfCode.Common;

namespace AdventOfCode.Day3;

public class GearRatios : IPuzzle<int>
{
    public int SolveFirstPuzzle(string input)
    {
        var lines = input.Split("\r\n");

        var schematicWidth = lines[0].Length;

        var symbols = new Dictionary<int, Dictionary<int, char>>();
        var numbers = new Dictionary<int, List<Number>>();

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];

            var (lineSymbols, lineNumbers) = ParseLine(line);
            symbols[i] = lineSymbols;
            numbers[i] = lineNumbers;
        }

        var finalNumbers = numbers.SelectMany(pair =>
                pair.Value
                    .Select(foundNumber => new
                    {
                        Number = foundNumber,
                        AdjacentPositions = CreateAdjacentSymbolPositions(pair.Key, foundNumber, schematicWidth, lines)
                    })
                    .Where(t => HasAdjacentSymbol(t.AdjacentPositions, symbols))
                    .Select(t => t.Number.Value))
            .ToList();

        return finalNumbers.Sum();
    }
  
    public int SolveSecondPuzzle(string input)
    {
        var lines = input.Split("\r\n");

        var schematicWidth = lines[0].Length;

        var symbols = new Dictionary<int, Dictionary<int, char>>();
        var numbers = new Dictionary<int, List<Number>>();

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];

            var (lineSymbols, lineNumbers) = ParseLine(line);
            symbols[i] = lineSymbols;
            numbers[i] = lineNumbers;
        }

        var finalNumbers = symbols.SelectMany(lineSymbols =>
        {
            var lineIdx = lineSymbols.Key;
            var indexes = lineSymbols.Value.Where(pair => pair.Value == '*').Select(pair => pair.Key).ToArray();

            return indexes.SelectMany(index =>
            {
                var adjacentPositions = CreateAdjacentNumberPositions(lineIdx, index, schematicWidth, lines);

                var overlappingNumbers = adjacentPositions.SelectMany(adjacentPosition =>
                {
                    var numberRanges = numbers[adjacentPosition.Key]
                        .Select(number => new { NumberValue = number.Value, NumberRange = new Range(number.StartIndex, number.EndIndex) });

                    return numberRanges
                        .Where(x => x.NumberRange.OverlapsWith(adjacentPosition.Value))
                        .Select(x => x.NumberValue);
                }).ToList();

                return overlappingNumbers.Count == 2 ? new[] { overlappingNumbers[0] * overlappingNumbers[1] } : Enumerable.Empty<int>();
            });
        }).ToList();

        return finalNumbers.Sum();
    }

    private static Dictionary<int, Range> CreateAdjacentNumberPositions(
        int lineIdx,
        int index,
        int schematicWidth,
        IReadOnlyCollection<string> lines)
    {
        var currentLineRanges =
            new List<int> { index - 1, index + 1 }.Where(x => x >= 0 && x < schematicWidth).ToList();
        var adjacentPositions = new Dictionary<int, Range>
        {
            {
                lineIdx,
                new Range(currentLineRanges.First(), currentLineRanges.Last())
            }
        };

        if (lineIdx - 1 >= 0)
        {
            var previousLineRanges =
                new List<int> { index - 1, index, index + 1 }.Where(x => x >= 0 && x < schematicWidth).ToList();
            adjacentPositions.Add(
                lineIdx - 1,
                new Range(previousLineRanges.First(), previousLineRanges.Last()));
        }

        if (lineIdx + 1 < lines.Count)
        {
            var nextLineRanges =
                new List<int> { index - 1, index, index + 1 }.Where(x => x >= 0 && x < schematicWidth).ToList();
            adjacentPositions.Add(
                lineIdx + 1,
                new Range(nextLineRanges.First(), nextLineRanges.Last()));
        }

        return adjacentPositions;
    }

    private static Dictionary<int, List<int>> CreateAdjacentSymbolPositions(
        int lineIdx,
        Number foundNumber,
        int schematicWidth,
        IReadOnlyCollection<string> lines)
    {
        var adjacentPositions = new Dictionary<int, List<int>>
        {
            { 
                lineIdx, 
                new List<int> { foundNumber.StartIndex - 1, foundNumber.EndIndex + 1 }.Where(x => x >= 0 && x < schematicWidth).ToList()
            }
        };
                
        if (lineIdx - 1 >= 0)
        {
            adjacentPositions.Add(
                lineIdx - 1,
                Enumerable.Range(foundNumber.StartIndex - 1, foundNumber.Length + 2).Where(x => x >= 0 && x < schematicWidth).ToList());
        }
                
        if (lineIdx + 1 < lines.Count)
        {
            adjacentPositions.Add(
                lineIdx + 1,
                Enumerable.Range(foundNumber.StartIndex - 1, foundNumber.Length + 2).Where(x => x >= 0 && x < schematicWidth).ToList());
        }

        return adjacentPositions;
    }

    private static bool HasAdjacentSymbol(
        Dictionary<int, List<int>> adjacentPositions,
        IReadOnlyDictionary<int, Dictionary<int, char>> symbols)
    {
        return adjacentPositions.Any(pair => symbols[pair.Key].Keys.Intersect(pair.Value).Any());
    }

    private static (Dictionary<int, char> Symbols, List<Number> Numbers) ParseLine(string line)
    {
        var numbers = new List<Number>();
        var symbols = new Dictionary<int, char>();

        var currentIndex = 0;

        while (currentIndex < line.Length)
        {
            var currentChar = line[currentIndex];

            if (currentChar == '.')
            {
                currentIndex++;
                continue;
            }

            if (!char.IsDigit(currentChar))
            {
                symbols[currentIndex] = currentChar;
                currentIndex++;
                continue;
            }
            
            var idx = currentIndex + 1;
            var number = currentChar.ToString();

            while (idx < line.Length && char.IsDigit(line[idx]))
            {
                number += line[idx];
                idx++;
            }

            numbers.Add(new Number
            {
                StartIndex = currentIndex,
                EndIndex = idx - 1,
                Value = int.Parse(number),
            });

            currentIndex = idx;
        }

        return (symbols, numbers);
    }
}