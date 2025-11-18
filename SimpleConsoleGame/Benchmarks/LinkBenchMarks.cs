using SimpleConsoleGame.Benchmarks;
using SimpleConsoleGame.LimitedList;

public class LinkBenchMarks
{
    public LimitedsList<string> BackPack { get; } = new(100);
    private MockUI _ui = new();

    public void Inventory_ForLoop()
    {
        for (int i = 0; i < BackPack.Count; i++)
        {
            _ui.AddMessage($"{i + 1}: {BackPack[i]}");
        }
    }

    public void Inventory_Linq()
    {
        foreach (var msg in BackPack.Select((item, index) => $"{index + 1}: {item}"))
        {
            _ui.AddMessage(msg);
        }
    }

    public void Inventory_Ling_ToList()
    {
        BackPack
            .Select((x, i) => $"{i + 1}: {x}")
            .ToList()
            .ForEach(_ui.AddMessage);
    }
}
