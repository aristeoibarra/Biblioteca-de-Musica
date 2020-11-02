using System.Collections.Generic;

namespace CapaDato.Models
{
    public partial class Genero
    {
        public Genero()
        {
            Cancion = new HashSet<Cancion>();
        }

        public int CveGenero { get; set; }
        public string NombreGenero { get; set; }

        public virtual ICollection<Cancion> Cancion { get; set; }
    }
}
