namespace VideoClubALFA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FacturasProveedor")]
    public partial class FacturasProveedor
    {
        [Key]
        public int? IdFacturaPedidoProveedor { get; set; }

        public int IdPedidoProveedor { get; set; }

        [Required]
        [StringLength(255)]
        public string FolioFacturaPedidoProveedor { get; set; }

        public int NumPagosFacturaPedidoProveedor { get; set; }

        public decimal TotalFacturaPedidoProveedor { get; set; }

        [Required]
        [StringLength(10)]
        public string RestanteFacturaPedidoProveedor { get; set; }

        public DateTime FG { get; set; }

        public virtual PedidosProveedor PedidosProveedor { get; set; }
    }
}
