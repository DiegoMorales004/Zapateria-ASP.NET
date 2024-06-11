using System;
using System.Collections.Generic;

namespace Zapateria.Models
{
    public partial class Stock
    {
        public int IdStock { get; set; }
        public int IdSucursal { get; set; }
        public int IdZapatos { get; set; }
        public int Cantidad { get; set; }

        public virtual Sucursale IdSucursalNavigation { get; set; } = null!;
        public virtual Zapato IdZapatosNavigation { get; set; } = null!;
    }
}
