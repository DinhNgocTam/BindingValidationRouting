using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string NickName { get; set; }

        public DateTime JoinedDate { get; set; }
        public List<PlayerInstrument> PlayerInstruments { get; set; }
    }
}
