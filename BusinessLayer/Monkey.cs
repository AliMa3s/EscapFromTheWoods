using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer {
   public class Monkey {
        public Monkey(int id, string name, Wood wood) {
            Id = id;
            Name = name;
            VisitedTrees = new List<Tree>();
            Wood = wood;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Tree> VisitedTrees { get; set; }
        public Wood Wood { get; set; }
    }
}
