using Lib_SAaplicacion.interfaces;
using Lib_SAaplicacion.entidades;
using Microsoft.EntityFrameworkCore;

namespace Lib_SAaplicacion.interfaces
{
    public class ProductosAplicacion : IProductosAplicacion
    {
        private IConexion IConexion;
        private Auditoria Auditoria;

        public ProductosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Productos Actualizar(Productos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            else
            {
                var entry = this.IConexion!.Entry<Productos>(entidad);
                entry.State = EntityState.Modified;

                Auditoria = new Auditoria
                {
                    Desc = "Se Actualizo" + entidad.Codigo,
                    Fecha = DateTime.Now
                };
                this.IConexion.Auditoria!.Add(Auditoria!);


                this.IConexion!.SaveChanges();
            }
            return entidad;


        }

        public Productos Borrar(Productos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");


            Auditoria = new Auditoria
            {
                Desc = "Se Borro ",
                Fecha = DateTime.Now
            };
            this.IConexion.Auditoria!.Add(Auditoria!);

            this.IConexion.Productos!.Remove(entidad!);

            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Productos> Buscar(Productos entidad)
        {
            Auditoria = new Auditoria
            {
                Desc = "Se Busco ",
                Fecha = DateTime.Now
            };
            return this.IConexion.Productos!
                .Include(x => x._tipo)
                .Where(x => x.Codigo!.Contains(entidad.Codigo!) ||
                            x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Productos> Consultar()
        {
            Auditoria = new Auditoria
            {
                Desc = "Se consulto ",
                Fecha = DateTime.Now
            };
            this.IConexion.Auditoria!.Add(Auditoria!);
            return this.IConexion.Productos!.ToList();
        }

        public Productos Insertar(Productos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            

            this.IConexion.Productos!.Add(entidad!);

            Auditoria = new Auditoria
            {
                Desc = "Se Agrego " + entidad.Codigo,
                Fecha = DateTime.Now
            };
            this.IConexion.Auditoria!.Add(Auditoria!);

            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Productos entidad)
        {
            return string.IsNullOrEmpty(entidad.Codigo) ||
                   string.IsNullOrEmpty(entidad.Nombre);
        }
    }
}