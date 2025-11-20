internal class Troll : Creature
{
    public Troll(Cell cell) : base(cell, "T ", 60)
    {
        Color = ConsoleColor.DarkCyan;
        Damage = 45;
    }
}


