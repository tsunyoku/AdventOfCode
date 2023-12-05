namespace AdventOfCode.Day1.Tests;

public class TrebuchetTests
{
    private string? _firstPuzzleExampleInput;
    private string? _secondPuzzleExampleInput;
    private string? _specialInput;
    private readonly IPuzzle<int> _trebuchet = new Trebuchet();

    [SetUp]
    public void Setup()
    {
        _firstPuzzleExampleInput = File.ReadAllText("trebuchetFirstPuzzleExampleInput.txt");
        _secondPuzzleExampleInput = File.ReadAllText("trebuchetSecondPuzzleExampleInput.txt");
        _specialInput = File.ReadAllText("trebuchetSpecialInput.txt");
    }

    [Test]
    public void ExampleInputFirstPuzzle()
    {
        Assert.That(_firstPuzzleExampleInput, Is.Not.Null);
        
        var result = _trebuchet.SolveFirstPuzzle(_firstPuzzleExampleInput!);

        Assert.That(result, Is.EqualTo(142));
    }
    
    [Test]
    public void SpecialInputFirstPuzzle()
    {
        Assert.That(_specialInput, Is.Not.Null);
        
        var result = _trebuchet.SolveFirstPuzzle(_specialInput!);

        Assert.That(result, Is.EqualTo(53194));
    }

    [Test]
    public void ExampleInputSecondPuzzle()
    {
        Assert.That(_secondPuzzleExampleInput, Is.Not.Null);
        
        var result = _trebuchet.SolveSecondPuzzle(_secondPuzzleExampleInput!);

        Assert.That(result, Is.EqualTo(281));
    }

    [Test]
    public void SpecialInputSecondPuzzle()
    {
        Assert.That(_specialInput, Is.Not.Null);
        
        var result = _trebuchet.SolveSecondPuzzle(_specialInput!);

        Assert.That(result, Is.EqualTo(54249));
    }
}