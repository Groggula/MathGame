using MathGame.Models;

namespace MathGame;

internal class GameEngine
{
    readonly Random random = new();

    int firstNumber;
    int secondNumber;

    internal void DivisionGame(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Helpers.GetDivisionNumbers();
        int score = 0;

        for (int i = 0; i < 10; i++)
        {
            int[] divisionNumbers = Helpers.GetDivisionNumbers();
            firstNumber = divisionNumbers[0];
            secondNumber = divisionNumbers[1];

            Console.WriteLine($"{firstNumber} / {secondNumber}");
            string result = Console.ReadLine()!;

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber / secondNumber)
            {
                Console.WriteLine($"Rätt svar!");
                score++;
            }
            else
            {
                Console.WriteLine($"Fel :(");
            }
        }

        Helpers.AddToHistory(score, GameType.Division, Difficulty.Enkelt);
        Console.WriteLine($"Spelet är slut. Du fick {score} poäng.");
    }

    internal void MultiplicationGame(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        int score = 0;

            Console.WriteLine(@$"Välj svårighetsgrad:
E - Enkelt
M - Mellan
S - Svårt"
            );

            Console.WriteLine("---------------------------------------------");

            var difficulty = Console.ReadLine();

            switch (difficulty!.Trim().ToLower())
            {
                case "e":
                    for (int i = 0; i < 10; i++)
                    {
                        firstNumber = random.Next(2, 6);
                        secondNumber = random.Next(2, 6);

                        Console.WriteLine($"{firstNumber} * {secondNumber}");
                        string result = Console.ReadLine()!;

                        result = Helpers.ValidateResult(result);

                        if (int.Parse(result) == firstNumber * secondNumber)
                        {
                            Console.WriteLine($"Rätt svar!");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine($"Fel :(");
                        }
                    }
                Helpers.AddToHistory(score, GameType.Multiplikation, Difficulty.Enkelt);
                break;
                case "m":
                    for (int i = 0; i < 10; i++)
                    {
                        firstNumber = random.Next(2, 8);
                        secondNumber = random.Next(2, 8);

                        Console.WriteLine($"{firstNumber} * {secondNumber}");
                        string result = Console.ReadLine()!;

                        result = Helpers.ValidateResult(result);

                        if (int.Parse(result) == firstNumber * secondNumber)
                        {
                            Console.WriteLine($"Rätt svar!");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine($"Fel :(");
                        }
                    }
                Helpers.AddToHistory(score, GameType.Multiplikation, Difficulty.Mellan);
                break;
                case "s":
                    for (int i = 0; i < 10; i++)
                    {
                        firstNumber = random.Next(3, 10);
                        secondNumber = random.Next(3, 10);

                        Console.WriteLine($"{firstNumber} * {secondNumber}");
                        string result = Console.ReadLine()!;

                        result = Helpers.ValidateResult(result);

                        if (int.Parse(result) == firstNumber * secondNumber)
                        {
                            Console.WriteLine($"Rätt svar!");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine($"Fel :(");
                        }
                    }
                Helpers.AddToHistory(score, GameType.Multiplikation, Difficulty.Svårt);
                break;
                default:
                    Console.WriteLine("Försök igen");
                    break;

            }
        

        
        Console.WriteLine($"Spelet är slut. Du fick {score} poäng.");
    }

    internal void SubtractionGame(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        int score = 0;

        for (int i = 0; i < 10; i++)
        {
            firstNumber = random.Next(1, 9);
            secondNumber = random.Next(1, 9);

            Console.WriteLine($"{firstNumber} - {secondNumber}");
            string result = Console.ReadLine()!;

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber - secondNumber)
            {
                Console.WriteLine($"Rätt svar!");
                score++;
            }
            else
            {
                Console.WriteLine($"Fel :(");
            }
        }
        Helpers.AddToHistory(score, GameType.Subtraktion, Difficulty.Enkelt);
        Console.WriteLine($"Spelet är slut. Du fick {score} poäng.");
    }

    internal void AdditionGame(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        int score = 0;

        for (int i = 0; i < 10; i++)
        {
            firstNumber = random.Next(1, 9);
            secondNumber = random.Next(1, 9);
            Console.WriteLine($"{firstNumber} + {secondNumber}");
            string result = Console.ReadLine()!;

            result = Helpers.ValidateResult(result);


            if (int.Parse(result) == firstNumber + secondNumber)
            {
                Console.WriteLine("Rätt svar!");
                score++;
            }
            else
            {
                Console.WriteLine("Fel :(");
            }
        }

        Helpers.AddToHistory(score, GameType.Addition, Difficulty.Enkelt);

        Console.WriteLine($"Spelet är slut. Du fick {score} poäng.");
    }

}
