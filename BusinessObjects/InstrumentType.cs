using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class InstrumentType
    {
        public int InstrumentTypeId { get; set; }
        public string Name { get; set; }

        public List<PlayerInstrument> PlayerInstruments { get; set; }
    }
}
