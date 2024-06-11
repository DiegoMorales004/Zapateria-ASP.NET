using System;
using System.Collections.Generic;

namespace Zapateria.Models
{
    public partial class Sucursale
    {
        public Sucursale()
        {
            Stocks = new HashSet<Stock>();
        }

        public int IdSucursal { get; set; }
        public string Nombre { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
        public DateTime FechaInicio { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
