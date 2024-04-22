using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionMiningAlgorithm.DataModel
{
    public class IntentionType
    {
        public int IntentionTypeId { get; set; }

        public string IntentionTypeName { get; set; }

        public List<StrategyType> StrategyTypes { get; set; }
    }
}
