

using SimpleConsoleGame.Extensions;
using SimpleConsoleGame.LimitedList;

internal class ConsoleUI
{
    private static MessageLog<string> _messageLog = new(6);

    internal static void Draw(IMap map)
    {
        Console.Clear();

        for (int y = 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
            {
                Cell? cell = map.GetCell(y, x);
                ArgumentNullException.ThrowIfNull(cell, nameof(cell));

                IDrawable drawable = map.Creatures.CreatureAt(cell)
                                                                 ?? cell.Items.FirstOrDefault() as IDrawable
                                                                 ?? cell;

                Console.ForegroundColor = drawable.Color;
                Console.Write(drawable.Symbol);
            }

            Console.WriteLine();
        }

        Console.ResetColor();
    }

    internal static ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;
    //{
    //    throw new NotImplementedException();
    //}
}