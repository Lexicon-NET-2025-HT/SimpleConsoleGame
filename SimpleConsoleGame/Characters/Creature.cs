using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

//Baseclass for all Characters
public abstract class Creature : IDrawable
{

    private Cell _cell;
    private int _health;
    private ConsoleColor _color;

    public string Symbol { get; }
    public int MaxHealth { get; }
    public int Damage { get; protected set; } = 50;
    public bool IsDead => _health <= 0;

    public string Name => GetType().Name;
    public static Action<string>? AddToLog { get; set; }

    public ConsoleColor Color
    {
        get => IsDead ? ConsoleColor.Gray : _color;
        protected set => _color = value;
    }
    
    public int Health
    {
        get => _health;
        set => _health = value >= MaxHealth ? MaxHealth : value;
    }
    
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

    public Creature(Cell cell, string symbol, int maxHealth = 50)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(symbol);
        Cell = cell; 
        Symbol = symbol;
        MaxHealth = maxHealth;
        Health = maxHealth;
        Color = ConsoleColor.Green;
    }

    internal void Attack(Creature target)
    {
        if (target.IsDead || this.IsDead) return;

        var attacker = this.Name;

        target.Health -= this.Damage;

        AddToLog?.Invoke($"The {attacker} attacks the {target.Name} for {this.Damage}");

        if (target.IsDead)
            AddToLog?.Invoke($"The {target.Name} is dead");
    }
}
