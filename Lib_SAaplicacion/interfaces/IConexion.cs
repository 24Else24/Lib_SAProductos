using Lib_SAaplicacion.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Lib_SAaplicacion.interfaces
{
    public interface IConexion
    {
        DbSet<Productos>? Productos { get; set; }
        DbSet<Auditoria>? Auditoria { get; set; }
        DbSet<Tipos>? Tipos { get; set; }


        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
