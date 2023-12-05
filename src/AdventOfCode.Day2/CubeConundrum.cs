using AdventOfCode.Common;

namespace AdventOfCode.Day2;

public class CubeConundrum : IPuzzle<int>
{
    private const int PossibleRedCubes = 12;
    private const int PossibleGreenCubes = 13;
    private const int PossibleBlueCubes = 14;

    public int SolveFirstPuzzle(string input)
    {
        var lines = input.Split("\r\n");

        var gameIds = new List<int>();

        foreach (var line in lines)
        {
            var game = Game.Parse(line);

            var impossibleGame = game.CubeSets.Any(cubes => 
                                                        cubes[Colour.Red] > PossibleRedCubes ||
                                                        cubes[Colour.Green] > PossibleGreenCubes ||
                                                        cubes[Colour.Blue] > PossibleBlueCubes);

            if (!impossibleGame)
            {
                gameIds.Add(game.Id);
            }
        }

        return gameIds.Sum();
    }

    public int SolveSecondPuzzle(string input)
    {
        var lines = input.Split("\r\n");

        var gamePowers = new List<int>();

        foreach (var line in lines)
        {
            var game = Game.Parse(line);

            var mostRequiredRed = game.CubeSets.Select(cubes => cubes[Colour.Red]).Max();
            var mostRequiredGreen = game.CubeSets.Select(cubes => cubes[Colour.Green]).Max();
            var mostRequiredBlue = game.CubeSets.Select(cubes => cubes[Colour.Blue]).Max();

            gamePowers.Add(mostRequiredRed * mostRequiredGreen * mostRequiredBlue);
        }

        return gamePowers.Sum();
    }
}