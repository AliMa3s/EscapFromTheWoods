using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BaseLogic {
   public class Combined {
        public List<Monkey> GenerateMapAndMonkeys(int woodId, int numberOfMonkeysInWood, int numberOfTreesPerWood, int width, int height) {
            var monkeys = new List<Monkey>();
            var c = new Create();
            var w = c.CreateWood(width, height, numberOfTreesPerWood, woodId);
            monkeys.AddRange(c.GenerateApesInWoods(numberOfMonkeysInWood, w));

            var esc = new Escape();
            List<Thread> threads = new List<Thread>();
            foreach (var m in monkeys) {
                ThreadStart ts = new ThreadStart(() => esc.Escap(m));
                Thread t = new Thread(ts);
                t.Start();
                threads.Add(t);
            }
            foreach (var t in threads) {
                t.Join();
            }
            return monkeys;
        }
    }
}
