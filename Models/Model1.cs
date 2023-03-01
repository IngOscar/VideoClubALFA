using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace VideoClubALFA.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Bonos> Bonos { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<FacturasProveedor> FacturasProveedor { get; set; }
        public virtual DbSet<PedidosClientes> PedidosClientes { get; set; }
        public virtual DbSet<PedidosProveedor> PedidosProveedor { get; set; }
        public virtual DbSet<Peliculas> Peliculas { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TipoTransacciones> TipoTransacciones { get; set; }
        public virtual DbSet<Transacciones> Transacciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bonos>()
                .Property(e => e.DescripcionBono)
                .IsUnicode(false);

            modelBuilder.Entity<Bonos>()
                .HasMany(e => e.Clientes)
                .WithRequired(e => e.Bonos)
                .HasForeignKey(e => e.IdBonos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.NumSocio)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.NombreCliente)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.ApellidoPaternoCliente)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.ApellidoMaternoCliente)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.TelefonoCliente)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.EmailCliente)
                .IsUnicode(false);

            modelBuilder.Entity<FacturasProveedor>()
                .Property(e => e.FolioFacturaPedidoProveedor)
                .IsUnicode(false);

            modelBuilder.Entity<FacturasProveedor>()
                .Property(e => e.RestanteFacturaPedidoProveedor)
                .IsFixedLength();

            modelBuilder.Entity<PedidosProveedor>()
                .Property(e => e.NumPedidoProveedor)
                .IsUnicode(false);

            modelBuilder.Entity<PedidosProveedor>()
                .HasMany(e => e.FacturasProveedor)
                .WithRequired(e => e.PedidosProveedor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Peliculas>()
                .Property(e => e.FolioPelicula)
                .IsUnicode(false);

            modelBuilder.Entity<Peliculas>()
                .Property(e => e.TituloPelicula)
                .IsUnicode(false);

            modelBuilder.Entity<Peliculas>()
                .Property(e => e.ClasificacionPelicula)
                .IsUnicode(false);

            modelBuilder.Entity<Peliculas>()
                .HasMany(e => e.PedidosClientes)
                .WithRequired(e => e.Peliculas)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.NumProveedor)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.NombreProveedor)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.RfcProveedor)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.TelefonoProveedor)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.EmailProveedor)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.EstadoProveedor)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .HasMany(e => e.PedidosProveedor)
                .WithRequired(e => e.Proveedores)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proveedores>()
                .HasMany(e => e.Peliculas)
                .WithRequired(e => e.Proveedores)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoTransacciones>()
                .Property(e => e.TipoTransaccion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoTransacciones>()
                .HasMany(e => e.PedidosClientes)
                .WithRequired(e => e.TipoTransacciones)
                .WillCascadeOnDelete(false);

           
        }
    }
}
