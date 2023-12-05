namespace AdventOfCode.Day2.Tests;

public class CubeConundrumTests
{
    private string? _exampleInput;
    private string? _specialInput;
    private readonly IPuzzle<int> _cubeConundrum = new CubeConundrum();

    [SetUp]
    public void Setup()
    {
        _exampleInput = File.ReadAllText("cubeConundrumExampleInput.txt");
        _specialInput = File.ReadAllText("cubeConundrumSpecialInput.txt");
    }

    [Test]
    public void ExampleInputFirstPuzzle()
    {
        Assert.That(_exampleInput, Is.Not.Null);
        
        var result = _cubeConundrum.SolveFirstPuzzle(_exampleInput!);

        Assert.That(result, Is.EqualTo(8));
    }

    [Test]
    public void SpecialInputFirstPuzzle()
    {
        Assert.That(_specialInput, Is.Not.Null);

        var result = _cubeConundrum.SolveFirstPuzzle(_specialInput!);

        Assert.That(result, Is.EqualTo(2727));
    }

    [Test]
    public void ExampleInputSecondPuzzle()
    {
        Assert.That(_exampleInput, Is.Not.Null);

        var result = _cubeConundrum.SolveSecondPuzzle(_exampleInput!);
        
        Assert.That(result, Is.EqualTo(2286));
    }
    
    [Test]
    public void SpecialInputSecondPuzzle()
    {
        Assert.That(_specialInput, Is.Not.Null);

        var result = _cubeConundrum.SolveSecondPuzzle(_specialInput!);

        Assert.That(result, Is.EqualTo(56580));
    }
}