

internal class Game
{
    public Game()
    {
    }

    internal void Run()
    {
        Init();
    }

    private void Init()
    {
        var map = new Map(height: 10, width: 10);
    }
}