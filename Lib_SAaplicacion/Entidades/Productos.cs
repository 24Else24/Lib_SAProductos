using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_SAaplicacion.entidades
{
    public class Productos
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public Decimal Precio { get; set; }
        
        public int Cantidad { get; set; }

        public int id_tipo { get; set; }


        [ForeignKey("id_tipo")] public Tipos? _tipo { get; set; }
    }
}