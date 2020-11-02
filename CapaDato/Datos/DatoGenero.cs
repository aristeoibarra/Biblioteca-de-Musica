using CapaDato.Models;
using System.Collections.Generic;
using System.Linq;

namespace CapaDato.Datos
{
    public class DatoGenero
    {
        readonly PostDbContext modeldb = new PostDbContext();

        public bool Guardar(Genero obj)
        {
            modeldb.Genero.Add(obj);
            modeldb.SaveChanges();
            return true;
        }

        public List<Genero> MostrarDatos()
        {
            var query = (from g in modeldb.Genero
                         select g);
            return query.ToList();
        }
    }
}
