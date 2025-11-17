
using SimpleConsoleGame.LimitedList;

//var name = "Kalle Anka";

//foreach (var item in name)
//{
//    Console.WriteLine(item);
//}

//var li2 = new List<int>();

//foreach (var item in li2)
//{
//    Console.WriteLine(item);
//}


IEnumerable<int> lm = new LimitedsList<int>(10);

//var res = lm.Where(i => i > 0).OrderBy()



//ILimitedsList<Player> lm2 = new LimitedsList<Player>(10);
//var lm25 = new LimitedsList<Dictionary<string, int>>(10);


//foreach (var item in lm)
//{
//    Console.WriteLine(item);
//}

var game = new Game();
game.Run();

Console.WriteLine("Hello, World!");
