namespace VideoClubALFA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transacciones
    {
        [Key]
        public int? IdTransaccion { get; set; }

        [StringLength(10)]
        public int IdPedido { get; set; }
        public int IdPedidoCliente { get; set; }
        public int IdPedidoProveedor { get; set; }
        public string TipoTransaccionCliente { get; set; }
        public string TipoTransaccionProveedor { get; set; }
        public string NombreCliente { get; set; }
        public string NombreProveedor { get; set; }       

        public decimal TotalTransaccion { get; set; }

        public DateTime FG { get; set; }
    }
}
