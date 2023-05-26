namespace MathGame;

internal class Menu
{
    readonly GameEngine _engine = new();
    internal void ShowMenu(DateTime date)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine($"Det är {date}. Öva matematik och bli bättre på huvudräkning!\n");

        bool isGameOn = true;

        do
        {
            Console.WriteLine(@$"Vad vill du spela? Välj från alternativen nedan:
V - Visa Highscore
A - Addition
S - Subtraktion
M - Multiplikation
D - Division
Q - Avsluta"
            );

            Console.WriteLine("---------------------------------------------");

            var gameSelected = Console.ReadLine();

            switch (gameSelected!.Trim().ToLower())
            {
                case "v":
                    Helpers.GetHighscore();
                    break;
                case "a":
                    _engine.AdditionGame("Addition - Enkelt");
                    break;
                case "s":
                    _engine.SubtractionGame("Subtraktion - Enkelt");
                    break;
                case "m":
                    _engine.MultiplicationGame("Multiplikation - Enkelt");
                    break;
                case "d":
                    _engine.DivisionGame("Division - Enkelt");
                    break;
                case "q":
                    Console.WriteLine("Hej då!");
                    isGameOn = false;

                    break;
                default:
                    Console.WriteLine("Försök igen");

                    break;

            }
        } while (isGameOn);
    }

}
