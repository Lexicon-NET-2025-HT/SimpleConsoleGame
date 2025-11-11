internal class Creature
{

    public string Symbol { get; }
    public ConsoleColor Color { get; protected set; } = ConsoleColor.Green;
    public Cell Cell { get; }

    public Creature(Cell cell, string symbol)
    {
        Cell = cell;
        Symbol = symbol;
    }
}

internal class Player : Creature
{
    public Player(Cell cell) : base(cell, "P ")
    {
        Color = ConsoleColor.White;
    }
}