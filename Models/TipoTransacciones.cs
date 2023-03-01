namespace VideoClubALFA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TipoTransacciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoTransacciones()
        {
            PedidosClientes = new HashSet<PedidosClientes>();
        }

        [Key]
        public int? IdTipoTransaccion { get; set; }

        [Required]
        [StringLength(255)]
        public string TipoTransaccion { get; set; }

        public DateTime FG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidosClientes> PedidosClientes { get; set; }
    }
}
