namespace AdventOfCode.Day4.Tests;

public class ScratchCardsTests
{
    private string? _exampleInput;
    private string? _specialInput;
    private readonly IPuzzle<int> _scratchCards = new ScratchCards();

    [SetUp]
    public void Setup()
    {
        _exampleInput = File.ReadAllText("scratchCardsExampleInput.txt");
        _specialInput = File.ReadAllText("scratchCardsSpecialInput.txt");
    }

    [Test]
    public void ExampleInputFirstPuzzle()
    {
        Assert.That(_exampleInput, Is.Not.Null);
        
        var result = _scratchCards.SolveFirstPuzzle(_exampleInput!);

        Assert.That(result, Is.EqualTo(13));
    }

    [Test]
    public void SpecialInputFirstPuzzle()
    {
        Assert.That(_specialInput, Is.Not.Null);

        var result = _scratchCards.SolveFirstPuzzle(_specialInput!);

        Assert.That(result, Is.EqualTo(26426));
    }
    
    [Test]
    public void ExampleInputSecondPuzzle()
    {
        Assert.That(_exampleInput, Is.Not.Null);
        
        var result = _scratchCards.SolveSecondPuzzle(_exampleInput!);

        Assert.That(result, Is.EqualTo(30));
    }
    
    [Test]
    public void SpecialInputSecondPuzzle()
    {
        Assert.That(_specialInput, Is.Not.Null);
        
        var result = _scratchCards.SolveSecondPuzzle(_specialInput!);

        Assert.That(result, Is.EqualTo(6227972));
    }
}