
using Microsoft.Extensions.Configuration;
using SimpleConsoleGame.Extensions;
using SimpleConsoleGame.LimitedList;

//Program starts here creates map and ui the 2 dependencis the Game needs.


IConfiguration config = new ConfigurationBuilder()
                                .SetBasePath(Environment.CurrentDirectory)
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .Build();

var uiFromConfig = config.GetSection("game:ui").Value;


if(uiFromConfig == "console")
{

}




//var x = config.GetSection("game:mapsettings:x").Value;
//var y = config.GetSection("game:mapsettings:y").Value;

//var mapS = config.GetSection("game:mapsettings").GetChildren();

var x = config.GetMapSizeFor("x");
var y = config.GetMapSizeFor("y");


var map = new Map(height: y, width: x);
var ui = new ConsoleUI(map);

var game = new Game(ui, map);
game.Run();

Console.WriteLine("Game Over!");

