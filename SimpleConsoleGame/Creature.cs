using System.Diagnostics.CodeAnalysis;

internal abstract class Creature : IDrawable
{

    private Cell _cell;

    public string Symbol { get; }
    public ConsoleColor Color { get; protected set; } = ConsoleColor.Green;
    public Cell Cell 
    {
        get => _cell;
        [MemberNotNull(nameof(_cell))]
        set
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            _cell = value;
        }
    }

    public Creature(Cell cell, string symbol)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(symbol);
        Cell = cell; 
        Symbol = symbol;
    }
}
