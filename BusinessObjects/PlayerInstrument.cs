using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class PlayerInstrument
    {
        public int PlayerInstrumentId { get; set; }
        public int PlayerId { get; set; }

        public Player Player { get; set; }
        public int InstrumentTypeId { get; set; }
        public InstrumentType InstrumentType { get; set; }
        public string ModelName { get; set; }
        public string Level { get; set; }
    }
}
