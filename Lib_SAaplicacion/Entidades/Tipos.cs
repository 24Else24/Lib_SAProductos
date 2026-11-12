using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib_SAaplicacion.entidades
{
    public class Tipos
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }

        [NotMapped] public List<Productos>? _producto { get; set; }


    }
}
