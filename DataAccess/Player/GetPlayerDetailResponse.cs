using DataAccess.PlayerInstrument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Player
{
    public class GetPlayerDetailResponse
    {
        public string NickName { get; set; }
        public DateTime JoinedDate { get; set; }
        public List<GetPlayerInstrumentResponse> PlayerInstruments { get; set; }
    }
}
