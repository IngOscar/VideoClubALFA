using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoClubALFA.Models
{
    public class StatusPedidos
    {
        [Key]
        public int? idStatusPedido { get; set; }
        public string descripcionStatusPedido { get; set; }
        
    }
}