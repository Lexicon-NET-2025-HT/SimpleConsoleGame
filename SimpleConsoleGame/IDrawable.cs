
//Everything that needs to be drawn to the console must implement this interface
internal interface IDrawable
{
    ConsoleColor Color { get; }
    string Symbol { get; }
}