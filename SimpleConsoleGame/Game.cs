



internal class Game
{
    private Map _map = null!;
    private Player _player = null!;

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

            //Act

            //Drawmap

            //Enenmyaction

            //Drawmap

            Console.ReadLine();
            
        }
        while (gameInProgress);
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
                Console.ForegroundColor = cell?.Color ?? ConsoleColor.Gray;
                Console.Write(cell.Symbol);
            }

            Console.WriteLine();
        }

        Console.ResetColor();
    }

    private void Init()
    {
        _map = new Map(height: 10, width: 10);
        _player = new Player();
    }
}