using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionMiningAlgorithm.DataModel
{
    public class StrategyGroup
    {
        public int StrategyGroupId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<Strategy> Strategies { get; set; }
    }
}
