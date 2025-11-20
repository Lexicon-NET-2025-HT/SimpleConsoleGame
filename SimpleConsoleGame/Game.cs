using SimpleConsoleGame.Extensions;
using SimpleConsoleGame.GameWorld;
using System.Threading.Channels;

internal class Game
{
    private IMap _map = null!;
    private Player _player = null!;
    private ConsoleUI _ui;
    private Dictionary<ConsoleKey, Action> _actionMeny;
    private bool _gameInProgress;

    public Game()
    {
         _ui = new ConsoleUI();
        _actionMeny = new Dictionary<ConsoleKey, Action>()
            {
                {ConsoleKey.P, PickUp },
                {ConsoleKey.I, Inventory },
                {ConsoleKey.D, Drop }
            };
    }

    private void Drop()
    {
        Item? item = _player.BackPack.FirstOrDefault();
        if (item != null && _player.BackPack.Remove(item))
        {
            _player.Cell.Items.Add(item);
            _ui.AddMessage($"Player dropped the {item}");
        }
        else
            _ui.AddMessage("Backpack is empty");
    }

    internal void Run()
    {
        Init();
        Play();

    }

    private void Play()
    {
        _gameInProgress = true;

        do
        {
            //Drawmap
            Drawmap();

            //Getcommand
            GetCommand();

            //Act

            //Drawmap

            //Enenmyaction

            //Drawmap

            //Console.ReadLine();

        }
        while (_gameInProgress);
    }

    private void GetCommand()
    {
        var keyPressed = _ui.GetKey();

        switch (keyPressed)
        {

            case ConsoleKey.UpArrow:
                Move(Direction.North);
                break;
            case ConsoleKey.DownArrow:
                Move(Direction.South);
                break;
            case ConsoleKey.LeftArrow:
                Move(Direction.West);
                break;
            case ConsoleKey.RightArrow:
                Move(Direction.East);
                break;
                //case ConsoleKey.P:
                //    PickUp();
                //    break;
                //case ConsoleKey.I:
                //    Inventory();
                //    break;

        }

        if (_actionMeny.ContainsKey(keyPressed))
        {
            _actionMeny[keyPressed]?.Invoke();
        }

    }

    private void Inventory()
    {
        for (int i = 0; i < _player.BackPack.Count; i++)
        {
            _ui.AddMessage($"{i + 1}: {_player.BackPack[i]}");
        }

        //foreach (var msg in _player.BackPack.Select((item, index) => $"{index + 1}: {item}"))
        //{
        //    ConsoleUI.AddMessage(msg);
        //}

        //_player.BackPack
        //   .Select((x, i) => $"{i + 1}: {x}")
        //   .ToList()
        //   .ForEach(ConsoleUI.AddMessage);

    }

    private void PickUp()
    {
        if (_player.BackPack.IsFull)
        {
            _ui.AddMessage("Backpack is full");
            return;
        }

        var items = _player.Cell.Items;
        var item = items.FirstOrDefault();

        if (item is null) return;

        if (_player.BackPack.Add(item))
        {
            _ui.AddMessage($"Player pick up the {item}");
            items.Remove(item);
        }

    }

    private void Move(Position movement)
    {
        Position newPosition = _player.Cell.Position + movement;
        Cell? newCell = _map.GetCell(newPosition);
        if (newCell is not null)
        {

            Creature? opponent = _map.CreatureAt(newCell);

            if (opponent is not null)
            {
                _player.Attack(opponent);
                opponent.Attack(_player);
            }

            _gameInProgress = !_player.IsDead;

            _player.Cell = newCell;
            if (newCell.Items.Any())
                _ui.AddMessage($"Tou see: {string.Join(", ", newCell.Items)}");
        }
    }

    private void Drawmap()
    {
        _ui.Clear();
        _ui.Draw(_map);
        _ui.PrintStats($"Health: {_player.Health}, Enemys: {_map.Creatures.Where(c => !c.IsDead).Count() - 1} ");
        _ui.PrintLog();
    }

    private void Init()
    {

        //ToDo: Read from config
        _map = new Map(height: 10, width: 10);
        Cell? playerCell = _map.GetCell(0, 0);
        _player = new Player(playerCell!);
        _map.Creatures.Add(_player);

        Creature.AddToLog = _ui.AddMessage;
       // Creature.AddToLog += Console.WriteLine;

        var r = new Random();

        RCell()?.Items.Add(Item.Coin());
        RCell()?.Items.Add(Item.Coin());
        RCell()?.Items.Add(Item.Coin());
        RCell()?.Items.Add(Item.Stone());
        RCell()?.Items.Add(Item.Stone());

        _map.Place(new Orc(RCell()));
        _map.Place(new Orc(RCell()));
        _map.Place(new Troll(RCell()));
        _map.Place(new Goblin(RCell()));
        _map.Place(new Goblin(RCell()));

        Cell RCell()
        {
            var width = r.Next(0, _map.Width);
            var height = r.Next(0, _map.Height);

            Cell? cell = _map.GetCell(height, width);
            ArgumentNullException.ThrowIfNull(cell);

            return cell;    
        }

    }
}