using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionMiningAlgorithm.DataModel
{
    public class EventRecord
    {
        public string ActivityName { get; set; }

        public int? EventId { get; set; }

        public DateTime Timestamp { get; set; }
        public int? ResourceId { get; set; }

        public string CaseName { get; set; }

        public string Value { get; set; }

        public double? TraceId { get; set; }

        public string Position { get; set; }

        public string Day { get; set; }
    }
}
