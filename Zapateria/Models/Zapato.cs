using System;
using System.Collections.Generic;

namespace Zapateria.Models
{
    public partial class Zapato
    {
        public Zapato()
        {
            Stocks = new HashSet<Stock>();
        }

        public int IdZapato { get; set; }
        public int Talla { get; set; }
        public string NombreZapato { get; set; } = null!;
        public DateTime FechaSalida { get; set; }
        public string Categoria { get; set; } = null!;
        public string? UrlImagen { get; set; }

        public virtual Talla TallaNavigation { get; set; } = null!;
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
