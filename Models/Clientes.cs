namespace VideoClubALFA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clientes
    {
        [Key]
        public int? IdCliente { get; set; }

        [Required]
        [StringLength(255)]
        public string NumSocio { get; set; }

        [Required]
        [StringLength(255)]
        public string NombreCliente { get; set; }

        [Required]
        [StringLength(255)]
        public string ApellidoPaternoCliente { get; set; }

        [Required]
        [StringLength(255)]
        public string ApellidoMaternoCliente { get; set; }

        [Required]
        [StringLength(20)]
        public string TelefonoCliente { get; set; }
        
        [Required]
        [StringLength(20)]
        public string DescripcionBono { get; set; }

        [Required]
        [StringLength(255)]
        public string EmailCliente { get; set; }

        public bool StatusCliente { get; set; }
        public string StatusClienteDescripcion { get; set; }

        public int IdBonos { get; set; }

        public int NumBonos { get; set; }

        public decimal PorcentajeSancion { get; set; }

        public DateTime FG { get; set; }

        public virtual Bonos Bonos { get; set; }

        public int DiasBono { get; set; }
    }
}
