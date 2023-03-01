namespace VideoClubALFA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PedidosClientes
    {
        [Key]
        public int? IdPedidoCliente { get; set; }

        public int IdCliente { get; set; }

        public int IdPelicula { get; set; }

        public int IdTipoTransaccion { get; set; }

        public int CantidadPeliculas { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaInicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaFinalizacion { get; set; }

        public decimal TotalPeliculas { get; set; }

        public DateTime FG { get; set; }

        public virtual Peliculas Peliculas { get; set; }

        public virtual TipoTransacciones TipoTransacciones { get; set; }

        public virtual Clientes Clientes { get; set; }
    }
}
