using CapaDato.Models;
using System.Collections.Generic;
using System.Linq;

namespace CapaDato.Datos
{
    public class DatoArtista
    {
        readonly PostDbContext modeldb = new PostDbContext();

        public bool Guardar(Artista obj)
        {
            modeldb.Artista.Add(obj);
            modeldb.SaveChanges();
            return true;
        }

        public List<Artista> MostrarDatos()
        {
            var query = (from a in modeldb.Artista
                         select a);

            return query.ToList();
        }
    }
}
