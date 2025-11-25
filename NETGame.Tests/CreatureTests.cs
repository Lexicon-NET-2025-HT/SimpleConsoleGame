using SimpleConsoleGame.GameWorld;

namespace NETGame.Tests;

public partial class CreatureTests
{
    private const string ValidSymbol = "T";
    private const string InvalidSymbol = "";
    private const int MaxHealth = 100;
    private const int DefaultDamage = 50;

    private readonly Cell _cell;
    private readonly Creature _creature;

    public CreatureTests()
    {
        _cell = new Cell(new Position(0, 0));
        _creature = CreateCreature(_cell, ValidSymbol, MaxHealth);
    }

    private static Creature CreateCreature(Cell cell, string symbol, int health, int damage = DefaultDamage)
    {
        return new TestCreature(cell, symbol, health, damage);
    }

    private static (Creature attacker, Creature target) SetupCombat(int attackerHealth, int targetHealth, int attackerDamage = DefaultDamage)
    {
        var cell1 = new Cell(new Position(0, 0));
        var cell2 = new Cell(new Position(0, 0));
        var attacker = CreateCreature(cell1, "A", attackerHealth, attackerDamage);
        var target = CreateCreature(cell2, "T", targetHealth);
        return (attacker, target);
    }

    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        //Arrange in Constructor

        //Act no act here just verify the objects state

        //Assert
        Assert.Equal(_cell, _creature.Cell);
        Assert.Equal(ValidSymbol, _creature.Symbol);
        Assert.Equal(MaxHealth, _creature.MaxHealth);
        Assert.Equal(MaxHealth, _creature.Health);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    
    public void JustDemo(int x)
    {

    }

    [Theory]
    [InlineData(null, typeof(ArgumentNullException))]
    [InlineData(InvalidSymbol, typeof(ArgumentException))]
    [InlineData(" ", typeof(ArgumentException))]
    public void Constructor_ShouldThrowCorrectException_OnInvalidSymbol(string? symbol, Type expectedExceptionType)
    {
        //Arrange in constructor

        //Act and Assert
        Assert.Throws(expectedExceptionType, () => CreateCreature(_cell, symbol!, MaxHealth));
    }

    [Fact]
    public void CellProperty_ShouldThrowException_OnNullValue()
    {
        //Arrange in constructor

        //Act and Assert
        Assert.Throws<ArgumentNullException>(() => _creature.Cell = null!);
    }

    [Fact]
    public void HealthProperty_ShouldNotExceedMaxHealth()
    {
        //Arrange in constructor

        //Act
        _creature.Health = 150;

        //Assert
        Assert.Equal(MaxHealth, _creature.Health);
    }

    [Fact]
    public void IsDead_ShouldReturnTrue_WhenHealthIsZeroOrLess()
    {
        //Arrange in constructor

        //Act
        _creature.Health = 0;

        //Assert
        Assert.True(_creature.IsDead);
    }

    [Fact]
    public void Color_ShouldReturnGray_WhenCreatureIsDead()
    {
        //Arrange in constructor

        //Act
        _creature.Health = 0;

        //Assert
        Assert.Equal(ConsoleColor.Gray, _creature.Color);
    }

    [Fact]
    public void Attack_ShouldReduceTargetHealth_WithDefaultDamage()
    {
        //Arrange
        var (attacker, target) = SetupCombat(100, 100);

        //Act
        attacker.Attack(target);

        //Assert
        Assert.Equal(MaxHealth - DefaultDamage, target.Health);
    }

    [Fact]
    public void Attack_ShouldReduceTargetHealth_WithCustomDamage()
    {
        //Arrange
        const int customDamage = 25;
        var (attacker, target) = SetupCombat(100, 100, customDamage);

        //Act
        attacker.Attack(target);

        //Assert
        Assert.Equal(MaxHealth - customDamage, target.Health);
    }

    [Fact]
    public void Attack_ShouldNotAffectTarget_WhenAttackerIsDead()
    {
        //Arrange
        const int initialTargetHealth = 100;
        var (attacker, target) = SetupCombat(0, initialTargetHealth);

        //Act
        attacker.Attack(target);

        //Assert
        Assert.Equal(initialTargetHealth, target.Health);
    }

    [Fact]
    public void Attack_ShouldNotAffectTarget_WhenTargetIsDead()
    {
        //Arrange
        var (attacker, target) = SetupCombat(100, 0);

        //Act
        attacker.Attack(target);

        //Assert
        Assert.Equal(0, target.Health);
    }

    [Fact]
    public void Attack_ShouldLogAttackMessage()
    {
        //Arrange
        var logMessages = new List<string>();
        Creature.AddToLog = logMessages.Add;
        var (attacker, target) = SetupCombat(100, 100);

        //Act
        attacker.Attack(target);

        //Assert
        var expected = string.Format(LogMessages.AttackMessage, attacker.Name, target.Name, attacker.Damage);
        Assert.Contains(expected, logMessages);

        Creature.AddToLog = null;
    }

    [Fact]
    public void Attack_ShouldLogDeathMessage()
    {
        //Arrange
        var logMessages = new List<string>();
        Creature.AddToLog = logMessages.Add;
        var (attacker, target) = SetupCombat(100, 50);

        //Act
        attacker.Attack(target);

        //Assert
        var expected = string.Format(LogMessages.DeathMessage, target.Name);
        Assert.Contains(expected, logMessages);

        Creature.AddToLog = null;
    }
}
