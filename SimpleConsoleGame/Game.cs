



internal class Game
{
    private Map _map = null!;
    private Creature _player = null!;

    public Game()
    {
    }

    internal void Run()
    {
        Init();
        Play();

    }

    private void Play()
    {
        bool gameInProgress = true;

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
        while (gameInProgress);
    }

    private void GetCommand()
    {
        var keyPressed = ConsoleUI.GetKey();

        switch (keyPressed)
        {
           
            case ConsoleKey.UpArrow:
                Move(_player.Cell.Y - 1, _player.Cell.X);
                break;
            case ConsoleKey.DownArrow:
                Move(_player.Cell.Y + 1, _player.Cell.X);
                break;
            case ConsoleKey.LeftArrow:
                Move(_player.Cell.Y, _player.Cell.X -1);
                break;
            case ConsoleKey.RightArrow:
                Move(_player.Cell.Y, _player.Cell.X + 1);
                break;
           
        }
    }

    private void Move(int y, int x)
    {
        Cell? newPosition = _map.GetCell(y, x);
        if(newPosition is not null) _player.Cell = newPosition;
    }

    private void Drawmap()
    {
        Console.Clear();

        for (int y = 0; y < _map.Height ; y++)
        {
            for (int x = 0; x < _map.Width; x++)
            {
                //ToDo: Fix nullable
                Cell? cell = _map.GetCell(y, x);
                ArgumentNullException.ThrowIfNull(cell, nameof(cell));

                IDrawable drawable = cell;

                foreach (Creature creature in _map.Creatures)
                {
                    if(creature.Cell == drawable)
                    {
                        drawable = creature;
                    }
                }


                Console.ForegroundColor = drawable.Color;
                Console.Write(drawable.Symbol);
            }

            Console.WriteLine();
        }

        Console.ResetColor();
    }

    private void Init()
    {
        //ToDo: Read from config
        _map = new Map(height: 10, width: 10);
        Cell? playerCell = _map.GetCell(0, 0);
        _player = new Player(playerCell!);
        _map.Creatures.Add(_player);
    }
}