
using SimpleConsoleGame.LimitedList;

var map = new Map(height: 10, width: 10);
var ui = new ConsoleUI(map);

var game = new Game(ui, map);
game.Run();

Console.WriteLine("Game Over!");

