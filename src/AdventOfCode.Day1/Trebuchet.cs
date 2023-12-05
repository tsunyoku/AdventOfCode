using AdventOfCode.Common;

namespace AdventOfCode.Day1;

public class Trebuchet : IPuzzle<int>
{
    private static readonly Dictionary<string, int> NumberTable = new()
    {
        { "1", 1 },
        { "2", 2 },
        { "3", 3 },
        { "4", 4 },
        { "5", 5 },
        { "6", 6 },
        { "7", 7 },
        { "8", 8 },
        { "9", 9 },
        { "zero", 0 },
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 }
    };

    public int SolveFirstPuzzle(string input)
    {
        var lines = input.Split("\r\n");

        var finalNumbers = new List<int>();

        foreach (var line in lines)
        {
            var numbers = line.Where(char.IsDigit).ToArray();

            var firstNumber = int.Parse(numbers.First().ToString());
            var lastNumber = int.Parse(numbers.Last().ToString());
            
            finalNumbers.Add(firstNumber * 10 + lastNumber);
        }

        return finalNumbers.Sum();
    }

    public int SolveSecondPuzzle(string input)
    {
        var lines = input.Split("\r\n");

        var finalNumbers = new List<int>();
        
        foreach (var line in lines)
        {
            var numbers = new SortedDictionary<int, int>();

            foreach (var (numberChar, numberValue) in NumberTable)
            {
                var left = line.IndexOf(numberChar, StringComparison.Ordinal);
                var right = line.LastIndexOf(numberChar, StringComparison.Ordinal);

                if (left != -1)
                {
                    numbers[left] = numberValue;
                }

                if (right != -1)
                {
                    numbers[right] = numberValue;
                }
            }

            var firstNumber = numbers.First().Value;
            var secondNumber = numbers.Last().Value;
            
            finalNumbers.Add(firstNumber * 10 + secondNumber);
        }

        return finalNumbers.Sum();
    }
}