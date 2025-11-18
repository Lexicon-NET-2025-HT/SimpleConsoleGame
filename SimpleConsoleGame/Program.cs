
using BenchmarkDotNet.Running;
using SimpleConsoleGame.LimitedList;


#if BENCHMARK
    BenchmarkRunner.Run<DemoBenchmarks>();
#else

var game = new Game();
game.Run();

Console.WriteLine("Hello, World!");

#endif