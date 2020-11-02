using System.Collections.Generic;

namespace CapaDato.Models
{
    public partial class Artista
    {
        public Artista()
        {
            Cancion = new HashSet<Cancion>();
        }

        public int CveArtista { get; set; }
        public string NombreArtista { get; set; }

        public virtual ICollection<Cancion> Cancion { get; set; }
    }
}
