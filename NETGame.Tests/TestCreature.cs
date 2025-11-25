namespace NETGame.Tests;

public partial class CreatureTests
{
    private class TestCreature : Creature
    {
        public TestCreature(Cell cell, string symbol, int health, int damage = DefaultDamage)
            : base(cell, symbol, health)
        {
            Damage = damage;
        }

    }
}
