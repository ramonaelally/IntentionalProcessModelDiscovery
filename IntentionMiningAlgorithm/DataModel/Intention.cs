using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionMiningAlgorithm.DataModel
{
    public class Intention
    {
        public int IntentionId { get; set; }

        public string IntentionName { get; set; }

        public List<Strategy> Strategies { get; set; }
    }
}
