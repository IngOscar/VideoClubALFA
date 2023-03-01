namespace VideoClubALFA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Peliculas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Peliculas()
        {
            PedidosClientes = new HashSet<PedidosClientes>();
        }

        [Key]
        public int? IdPelicula { get; set; }

        public int IdProveedor { get; set; }

        [Required]
        [StringLength(255)]
        public string FolioPelicula { get; set; }

        public int ExistenciaPelicula { get; set; }

        public int DisponiblePeliculas { get; set; }

        [Required]
        [StringLength(255)]
        public string TituloPelicula { get; set; }

        [Required]
        [StringLength(1)]
        public string ClasificacionPelicula { get; set; }

        public decimal PrecioXDia { get; set; }

        public bool Status { get; set; }

        public DateTime FG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidosClientes> PedidosClientes { get; set; }

        public virtual Proveedores Proveedores { get; set; }
    }
}
