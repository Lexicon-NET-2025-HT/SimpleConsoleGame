using SimpleConsoleGame.GameWorld;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

internal class Map : IMap
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
    public Cell? GetCell(int y, int x)
    {
        return (x < 0 || x >= Width || y < 0 || y >= Height) ? null : _cells[y, x];
    }

    public Cell? GetCell(Position newPosition)
    {
        return GetCell(newPosition.Y, newPosition.X);
    }

    public void Place(Creature creature)
    {
        if(Creatures.FirstOrDefault(c => c.Cell == creature.Cell) == null)
        {
            Creatures.Add(creature);
        }
    }

    public Creature? CreatureAt(Cell cell)
    {

        //var t = typeof(Player);
        foreach (Creature creature in Creatures)
        {
            if(creature.Name == nameof(Player))
            {

            }
        }


        foreach (var item in Creatures)
        {
            if (item.GetType() == typeof(Player))
            {
                var p = (Player)item;

                var p2 = item as Player;
            }


            if (item is Player)
            {
                var p = (Player)item;

                var p2 = item as Player;
            }

            if (item is Player player)
            {

            }


        }



        return Creatures.FirstOrDefault(c => c.Cell == cell);
    }
}