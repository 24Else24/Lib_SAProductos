using LibAplicacion.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lib_SAPresentacion.interfaces;
using Lib_SAaplicacion.entidades;

namespace FrontEnd.Pages.Ventanas
{
    public class ProductosModel : PageModel
    {
        private IProductosPresentacion IProductosPresentacion;

        public ProductosModel(IProductosPresentacion IProductosPresentacion)
        {
            this.IProductosPresentacion = IProductosPresentacion;
            this.Filtro = new Productos();
        }

        [BindProperty] public List<Productos> Lista { get; set; }
        [BindProperty] public Productos? Filtro { get; set; }
        [BindProperty] public Productos? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;


        public void OnGet() { OnPostBtBuscar(); }

        public void OnPostBtBuscar()
        {
            try
            {
                this.Filtro!.Codigo = this.Filtro!.Codigo ?? "";
                this.Filtro!.Nombre = this.Filtro!.Nombre ?? "";
                Lista = this.IProductosPresentacion.Buscar(this.Filtro!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtNuevo()
        {
            try
            {
                Formulario = true;
                this.Actual = new Productos();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (this.Actual!.Id == 0)
                    this.Actual = this.IProductosPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IProductosPresentacion.Actualizar(this.Actual!);
                OnPostBtBuscar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtBuscar();
            }
        }
        public void OnPostBtEditar(string data)
        {
            try
            {
                Formulario = true;
                OnPostBtBuscar();
                Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtPregBorrar(string data)
        {
            try
            {
                Borrar = true;
                OnPostBtBuscar();
                Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (this.Actual!.Id == 0)
                    return;
                this.Actual = this.IProductosPresentacion.Borrar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtBuscar();
            }
        }
    }
}
