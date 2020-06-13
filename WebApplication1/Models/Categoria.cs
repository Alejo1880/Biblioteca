using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Libro = new HashSet<Libro>();
        }

        public int Idcategoria { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Libro> Libro { get; set; }
    }
}
