

using SimpleConsoleGame.Extensions;
using SimpleConsoleGame.LimitedList;

public class ConsoleUI : IUI
{
    private MessageLog<string> _messageLog = new(6);
    private readonly IMap _map;

    public void AddMessage(string message) => _messageLog.Add(message);

    public ConsoleUI(IMap map)
    {
        _map = map;
    }

    public void PrintLog()
    {
        _messageLog.Print(m => Console.WriteLine(m + new string(' ', Console.WindowWidth - m.Length)));
    }

    //private static void HowToPrint(string message)
    //{
    //    //...
    //    //...
    //    //...
    //    Console.WriteLine(message);

    //}

    public void Draw()
    {

        for (int y = 0; y < _map.Height; y++)
        {
            for (int x = 0; x < _map.Width; x++)
            {
                Cell? cell = _map.GetCell(y, x);
                ArgumentNullException.ThrowIfNull(cell, nameof(cell));

                //Order of priority the first to match get printed out
                //1. Creatures
                //2. Items
                //3. Cell
                //Creatures Items and Cells implements IDrawable and can be threated as one
                IDrawable drawable = _map.CreatureAt(cell)
                                                                 ?? cell.Items.FirstOrDefault() as IDrawable
                                                                 ?? cell;

                Console.ForegroundColor = drawable.Color;
                Console.Write(drawable.Symbol);
            }

            Console.WriteLine();
        }

        Console.ResetColor();
    }

    public ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;

    public void Clear()
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);
    }

    public void PrintStats(string stats)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(stats);
        Console.ResetColor();
    }
}