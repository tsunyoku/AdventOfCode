namespace AdventOfCode.Day3.Tests;

public class GearRatiosTests
{
    private string? _exampleInput;
    private string? _specialInput;
    private readonly IPuzzle<int> _gearRatios = new GearRatios();

    [SetUp]
    public void Setup()
    {
        _exampleInput = File.ReadAllText("gearRatiosExampleInput.txt");
        _specialInput = File.ReadAllText("gearRatiosSpecialInput.txt");
    }

    [Test]
    public void ExampleInputFirstPuzzle()
    {
        Assert.That(_exampleInput, Is.Not.Null);
        
        var result = _gearRatios.SolveFirstPuzzle(_exampleInput!);

        Assert.That(result, Is.EqualTo(4361));
    }

    [Test]
    public void SpecialInputFirstPuzzle()
    {
        Assert.That(_specialInput, Is.Not.Null);
        
        var result = _gearRatios.SolveFirstPuzzle(_specialInput!);

        Assert.That(result, Is.EqualTo(528799));
    }
    
    [Test]
    public void ExampleInputSecondPuzzle()
    {
        Assert.That(_exampleInput, Is.Not.Null);
        
        var result = _gearRatios.SolveSecondPuzzle(_exampleInput!);

        Assert.That(result, Is.EqualTo(467835));
    }

    [Test]
    public void SpecialInputSecondPuzzle()
    {
        Assert.That(_specialInput, Is.Not.Null);

        var result = _gearRatios.SolveSecondPuzzle(_specialInput!);
        
        Assert.That(result, Is.EqualTo(84907174));
    }
}