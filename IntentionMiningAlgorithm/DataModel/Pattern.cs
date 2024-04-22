using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionMiningAlgorithm.DataModel
{
    public class Pattern
    {
        public string PatternName { get; set; }

        public int PatternId { get; set; }

        public List<string> PatternActivities { get; set; }
    }
}
