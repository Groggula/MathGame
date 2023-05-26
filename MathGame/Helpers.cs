using MathGame.Models;

namespace MathGame;

internal class Helpers
{
    private const string FileName = "highscore.txt";
    internal static List<Game> games = new();
    internal static void GetHighscore()
    {
        var orderHighscoreByDescending = games.OrderByDescending(x => x.Score);
        Console.Clear();
        Console.WriteLine("Highscore");
        Console.WriteLine("--------------------------");
        foreach (var game in orderHighscoreByDescending)
        {
            Console.WriteLine($"{game.Date} - {game.Type} {game.difficulty} {game.Score} poäng - {game.Name}");
        }
        Console.WriteLine("--------------------------\n");
        Console.ReadLine();
    }

    internal static void AddToHistory(int gameScore, GameType gameType, Difficulty difficulty)
    {
        games!.Add(new Game
        {
            Date = DateTime.UtcNow,
            Score = gameScore,
            Type = gameType,
            difficulty = difficulty,
            Name = GetName(),
        });

        SaveHighScoreToFile();
    }

    private static void SaveHighScoreToFile()
    {
        using (StreamWriter writer = new(FileName))
        {
            foreach (var game in games)
            {
                string gameData = $"{game.Date}|{game.Score}|{game.Type}|{game.difficulty}|{game.Name}";
                writer.WriteLine(gameData);
            }
        }
    }

    internal static void LoadHistoryFromFile()
    {
        if (File.Exists(FileName))
        {
            games.Clear();

            using (StreamReader reader = new(FileName))
            {
                string line;
                while ((line = reader.ReadLine()!) != null)
                {
                    string[] gameData = line.Split('|');

                    if (gameData.Length == 5 &&
                        DateTime.TryParse(gameData[0], out DateTime date) &&
                        int.TryParse(gameData[1], out int score) &&
                        Enum.TryParse(gameData[2], out GameType type) &&
                        Enum.TryParse(gameData[3], out Difficulty difficulty))
                    {
                        string name = gameData[4];
                        games.Add(new Game
                        {
                            Date = date,
                            Score = score,
                            Type = type,
                            difficulty = difficulty,
                            Name = name
                        });
                    }
                }
            }
        }
    }

    internal static int[] GetDivisionNumbers()
    {
        Random random = new();
        int firstNumber = random.Next(1, 10);
        int secondNumber = random.Next(1, 10);

        int[] result = new int[2];
        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(1, 10);
            secondNumber = random.Next(1, 10);
        }

        result[0] = firstNumber;
        result[1] = secondNumber;


        return result;
    }

    internal static string ValidateResult(string result)
    {
        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Du behöver ange en siffra, försök igen.");
            result = Console.ReadLine()!;
        }

        return result;
    }

    internal static string GetName()
    {
        Console.WriteLine("Skriv in ditt namn");
        var name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Du behöver ange ett namn.");
            name = Console.ReadLine()!;
        }
        return name;
    }
}
