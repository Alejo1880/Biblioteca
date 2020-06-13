using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Libro = new HashSet<Libro>();
        }

        public int Idautor { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Libro> Libro { get; set; }
    }
}
