using BenchmarkDotNet.Attributes;


[ShortRunJob]
[MemoryDiagnoser]
public class DemoBenchmarks
{
    private LinqBenchMarks _benchmarks = null!;

    [GlobalSetup]
    public void Setup()
    {
        _benchmarks = new LinqBenchMarks();

        for (int i = 0; i < 100_000; i++)
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
        _benchmarks.Inventory_Linq_With_ToList();
    }

    [Benchmark]
    public void LinqVersionWithForEachExtension()
    {
        _benchmarks.Inventory_Linq_ForEachExtension();
    }
   
    [Benchmark]
    public void ForEachInLimitedList()
    {
        _benchmarks.Inventory_Foreach_From_Backpack();
    }
}
