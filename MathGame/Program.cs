using MathGame;

Menu menu = new();

var date = DateTime.UtcNow;

List<string> games = new();

Helpers.LoadHistoryFromFile();

menu.ShowMenu(date);




