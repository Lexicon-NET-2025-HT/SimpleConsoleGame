using SimpleConsoleGame.GameWorld;

public class Cell : IDrawable
{
    public string Symbol => ". ";
    public ConsoleColor Color { get; }
    public Position Position { get; }

    public List<Item> Items { get; }

    public Cell(Position position)
    {
        Color = ConsoleColor.Red;
        Position = position;
        Items = new List<Item>();
    }
}