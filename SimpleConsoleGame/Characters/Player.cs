using SimpleConsoleGame.GameWorld;
using SimpleConsoleGame.LimitedList;

internal class Player : Creature
{
    public LimitedsList<Item> BackPack { get; }
    public Player(Cell cell) : base(cell, "P ")
    {
        Color = ConsoleColor.White;
        BackPack = new LimitedsList<Item>(3);
    }

}