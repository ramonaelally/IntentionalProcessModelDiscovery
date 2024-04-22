using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionMiningAlgorithm.DataModel
{
    public class StrategyType
    {
        public int StrategyTypeId { get; set; }

        public string StrategyTypeName { get; set; }

        public int IntentionTypeId { get; set; }

        public int PreviousStrategyTypeId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<ActivityType> ActivityTypes { get; set; }
    }
}
