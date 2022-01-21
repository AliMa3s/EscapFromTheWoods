using BaseLogic;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncLayer {
   public static class AsyncExecution {
        private static async Task<List<Monkey>> CreateExportToFiles(int woodId, int numberOfMonkeys, int numberOfTrees, int width, int height) {
            var combo = new Combined();
            var m = combo.GenerateMapAndMonkeys(woodId, numberOfMonkeys, numberOfTrees, width, height);
            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => ExportToFile.Export.ExportToBitMap(m)));
            tasks.Add(Task.Run(() => ExportToFile.Export.ExportToTextFile(m)));
            Task.WaitAll(tasks.ToArray());
            return m;
        }
        public static async void CreateExportToDB(int numberOfWoods, int numberOfMonkeys, int numberOfTrees, int width, int height) {
            List<Task<List<Monkey>>> tasks = new List<Task<List<Monkey>>>();
            List<Monkey> monkeys = new List<Monkey>();
            for (int i = 0; i < numberOfWoods; i++) {
                tasks.Add(CreateExportToFiles(i, numberOfMonkeys, numberOfTrees, width, height));
            }
            var listListMonkeys = await Task.WhenAll(tasks.ToArray());
            foreach (var monkeyList in listListMonkeys) {
                foreach (var monkey in monkeyList) {
                    monkeys.Add(monkey);
                }
            }
            var exp = new DataLayer.Export();
            exp.ExportToDB(monkeys);
        }
    }
}
