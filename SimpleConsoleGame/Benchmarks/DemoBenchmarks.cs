using BenchmarkDotNet.Attributes;


[ShortRunJob]
[MemoryDiagnoser]
public class DemoBenchmarks
{
    private LinkBenchMarks _benchmarks = null!;

    [GlobalSetup]
    public void Setup()
    {
        _benchmarks = new LinkBenchMarks();


        for (int i = 0; i < 100; i++)
        {
            _benchmarks.BackPack.Add("Test");
        }
    }

    [Benchmark(Baseline = true)]
    public void ForLoopVersion()
    {
        _benchmarks.Inventory_ForLoop();
    }

    [Benchmark]
    public void LinqVersion()
    {
        _benchmarks.Inventory_Linq();
    }

    [Benchmark]
    public void LinqVersionWithToList()
    {
        _benchmarks.Inventory_Ling_ToList();
    }
}
