using AdventOfCode.Common;

namespace AdventOfCode.Day2;

public class Game
{
    public required int Id { get; init; }
    public required List<Dictionary<Colour, int>> CubeSets { get; init; }

    public static Game Parse(string line)
    {
        var gameSplit = line.Split(": ", count: 2);
        var gameId = int.Parse(gameSplit[0][5..]);

        var gameCubeSets = new List<Dictionary<Colour, int>>();

        var cubeSets = gameSplit[1].Split("; ");
        foreach (var cubeSet in cubeSets)
        {
            var gameCubes = new Dictionary<Colour, int>()
            {
                { Colour.Red, 0 },
                { Colour.Green, 0 },
                { Colour.Blue, 0 },
            };

            var cubes = cubeSet.Split(", ");
            foreach (var cube in cubes)
            {
                var (cubeCountString, cubeColourString) = cube.Split(" ", 2);

                var cubeColour = cubeColourString[0] switch
                {
                    'r' => Colour.Red,
                    'g' => Colour.Green,
                    'b' => Colour.Blue,
                    _ => throw new InvalidOperationException(),
                };

                gameCubes[cubeColour] += int.Parse(cubeCountString);
            }
            
            gameCubeSets.Add(gameCubes);
        }

        return new Game
        {
            Id = gameId,
            CubeSets = gameCubeSets,
        };
    }
}