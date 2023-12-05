namespace AdventOfCode.Common;

public interface IPuzzle<out T>
{ 
    T SolveFirstPuzzle(string input);
    T SolveSecondPuzzle(string input);
}