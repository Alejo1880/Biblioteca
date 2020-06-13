using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Socio
    {
        public int Idsocio { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public DateTime? Fechanacimiento { get; set; }
        public bool? Estado { get; set; }
    }
}
