internal class Goblin : Creature
{
    public Goblin(Cell cell) : base(cell, "G ", 20)
    {
        Color = ConsoleColor.DarkBlue;
        Damage = 60;
    }
}


