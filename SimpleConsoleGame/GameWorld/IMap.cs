using SimpleConsoleGame.GameWorld;

internal interface IMap
{
    List<Creature> Creatures { get; }
    int Height { get; }
    int Width { get; }

    Cell? GetCell(int y, int x);
    Cell? GetCell(Position newPosition);
    Creature? CreatureAt(Cell cell);
    void Place(Creature creature);
}