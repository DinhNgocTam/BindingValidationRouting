using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PlayerInstrument
{
    public class CreatePlayerInstrumentRequest
    {
        public int InstrumentTypeId { get; set; }
        public string ModelName { get; set; }
        public string Level { get; set; }
    }
}
