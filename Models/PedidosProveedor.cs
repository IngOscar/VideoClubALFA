namespace VideoClubALFA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PedidosProveedor")]
    public partial class PedidosProveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PedidosProveedor()
        {
            FacturasProveedor = new HashSet<FacturasProveedor>();
        }

        [Key]
        public int? IdPedidoProveedor { get; set; }

        public int IdProveedor { get; set; }
        public int idTipoTransaccion { get; set; }

        [Required]
        [StringLength(255)]
        public string NumPedidoProveedor { get; set; }

        public decimal TotalPedidoProveedor { get; set; }

        public DateTime FG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacturasProveedor> FacturasProveedor { get; set; }

        public virtual Proveedores Proveedores { get; set; }
    }
}
