using LibAplicacion.nucleo;
using Microsoft.EntityFrameworkCore;
using Lib_SAaplicacion.entidades;
using Lib_SAaplicacion.interfaces;

namespace LibAplicacion.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatosGenerales.StringConexion()!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Productos>? Productos { get; set; }
        public DbSet<Auditoria>? Auditoria { get; set; }
        public DbSet<Tipos>? Tipos { get; set; }

    }
}
