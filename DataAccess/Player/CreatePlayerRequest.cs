using DataAccess.PlayerInstrument;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Player
{
    public class CreatePlayerRequest
    {
        [Required]
        public string NickName { get; set; } = string.Empty; // Khởi tạo giá trị mặc định

        [Required]
        public List<CreatePlayerInstrumentRequest> PlayerInstruments { get; set; } = new List<CreatePlayerInstrumentRequest>(); // Khởi tạo danh sách rỗng
    }
}
