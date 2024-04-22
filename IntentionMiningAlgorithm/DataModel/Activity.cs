using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionMiningAlgorithm.DataModel
{
    public class Activity
    {
        public int ActivityId { get; set; }

        public int ActivityTypeId { get; set; }

        public string ActivityName { get; set; }

        public DateTime Timestamp { get; set; }

        public string CaseName { get; set; }
    }
}
