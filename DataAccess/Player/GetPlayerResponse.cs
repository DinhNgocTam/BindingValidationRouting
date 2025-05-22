using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Player
{
    public class GetPlayerResponse
    {
        public int PlayerId { get; set; }
        public string NickName { get; set; }
        public DateTime JoinedDate { get; set; }
        public int InstrumentSubmittedCount { get; set; }
    }
}
