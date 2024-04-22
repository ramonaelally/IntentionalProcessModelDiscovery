using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionMiningAlgorithm.DataModel
{
    public class Strategy
    {
        public int StrategyId { get; set; }

        public int StrategyTypeId { get; set; }

        public string StrategyName { get; set; }

        public int IntentionId { get; set; }

        public int PreviousStrategyId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<Activity> Activities { get; set; }

        public int ResourceId { get; set; }

        public string Day { get; set; }

        public bool IsComplete { get; set; }
    }
}
