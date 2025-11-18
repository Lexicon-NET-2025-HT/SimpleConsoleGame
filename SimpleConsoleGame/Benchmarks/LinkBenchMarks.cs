using SimpleConsoleGame.LimitedList;

public class LinkBenchMarks
{
    public LimitedsList<string> BackPack { get; } = new(100);

    public void Inventory_ForLoop()
    {
        for (int i = 0; i < BackPack.Count; i++)
        {
            
        }
    }

    public void Inventory_Linq()
    {
        foreach (var msg in BackPack.Select((item, index) => $"{index + 1}: {item}"))
        {
            
        }
    }

    public void Inventory_Ling_ToList()
    {
        BackPack
            .Select((x, i) => $"{i + 1}: {x}")
            .ToList()
            .ForEach();
    }
}
