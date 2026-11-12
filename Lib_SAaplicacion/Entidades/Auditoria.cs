using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_SAaplicacion.entidades
{
    public class Auditoria
    {
        public int Id { get; set; }

        public DateTime? Fecha { get; set; }

        public String? Desc { get; set; }

    }
}