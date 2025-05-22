using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Player
{
    public class UpdatePlayerRequest
    {
        [Required]
        public string NickName { get; set; }
    }
}
