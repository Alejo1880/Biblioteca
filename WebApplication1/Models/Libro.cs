using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Libro
    {
        public int IdLibro { get; set; }
        public string Nombre { get; set; }
        public int Idcategoria { get; set; }
        public int Idautor { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }

        public virtual Autor IdautorNavigation { get; set; }
        public virtual Categoria IdcategoriaNavigation { get; set; }
    }
}
