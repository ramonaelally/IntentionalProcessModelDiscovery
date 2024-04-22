using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionMiningAlgorithm.DataModel
{
    public class MAPItem
    {
        public Intention Intention { get; set; }

        public List<Strategy> Strategies { get; set; }
    }
}
