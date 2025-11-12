
using SimpleConsoleGame;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

internal class Map
{

    private Cell[,] _cells;
    
    public int Height { get; }
    public int Width { get; }

    public List<Creature> Creatures { get; } = new List<Creature>();

    public Map(int height, int width)
    {
        Height = height;
        Width = width;

        _cells = new Cell[height, width];

        for (int y = 0; y < Height; y++)
            for (int x = 0; x < Width; x++)
                _cells[y, x] = new Cell(new Position(y, x));
        
    }

    //[return: MaybeNull]
    internal Cell? GetCell(int y, int x)
    {
       return (x < 0 || x >= Width || y < 0 || y >= Height) ? null : _cells[y, x];
    }

    internal Cell? GetCell(Position newPosition)
    {
       return GetCell(newPosition.Y, newPosition.X);
    }
}