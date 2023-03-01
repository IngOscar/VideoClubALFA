namespace VideoClubALFA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Proveedores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedores()
        {
            PedidosProveedor = new HashSet<PedidosProveedor>();
            Peliculas = new HashSet<Peliculas>();
        }

        [Key]
        public int? IdProveedor { get; set; }

        [Required]
        [StringLength(255)]
        public string NumProveedor { get; set; }

        [Required]
        [StringLength(255)]
        public string NombreProveedor { get; set; }

        [Required]
        [StringLength(255)]
        public string RfcProveedor { get; set; }

        [Required]
        [StringLength(20)]
        public string TelefonoProveedor { get; set; }

        [Required]
        [StringLength(255)]
        public string EmailProveedor { get; set; }

        [Required]
        [StringLength(255)]
        public string EstadoProveedor { get; set; }

        public DateTime FG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidosProveedor> PedidosProveedor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Peliculas> Peliculas { get; set; }
    }
}
