using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionMiningAlgorithm.DataModel
{
    public class Section
    {
        public string IntentionSource { get; set; }

        public string IntentionTarget { get; set; }

        public StrategyItem StrategyItem { get; set; }
    }
}
