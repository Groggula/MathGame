namespace MathGame.Models;

internal class Game
{
    internal DateTime Date { get; set; }
    internal GameType Type { get; set; }
    internal Difficulty difficulty { get; set; }
    internal int Score { get; set; }
    internal string? Name { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraktion,
    Multiplikation,
    Division,
}

internal enum Difficulty
{
    Enkelt,
    Mellan,
    Svårt,
}