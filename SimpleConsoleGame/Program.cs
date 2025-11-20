
using SimpleConsoleGame.LimitedList;

//Program starts here creates map and ui the 2 dependencis the Game needs.
var map = new Map(height: 10, width: 10);
var ui = new ConsoleUI(map);

var game = new Game(ui, map);
game.Run();

Console.WriteLine("Game Over!");

