using System;
using System.Collections.Generic;

namespace Zapateria.Models
{
    public partial class Talla
    {
        public Talla()
        {
            Zapatos = new HashSet<Zapato>();
        }

        public int IdTalla { get; set; }
        public decimal? TallaEuropea { get; set; }
        public decimal? TallaAmerica { get; set; }
        public decimal? TallaCentimetros { get; set; }

        public virtual ICollection<Zapato> Zapatos { get; set; }
    }
}
