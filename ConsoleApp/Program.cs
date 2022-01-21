using System;
using System.Diagnostics;

namespace ConsoleApp {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello Welcome to Escape from the woods!");
            Stopwatch watch = new Stopwatch();
            watch.Start();
            AsyncLayer.AsyncExecution.CreateExportToDB(3, 10, 5000, 100, 100);
            watch.Stop();
            Console.WriteLine("Time ellapsed " + watch.Elapsed);
        }
    }
}
