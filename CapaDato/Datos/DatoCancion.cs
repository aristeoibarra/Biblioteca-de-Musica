using CapaDato.Entidades;
using CapaDato.Models;
using System.Collections.Generic;
using System.Linq;

namespace CapaDato.Datos
{
    public class DatoCancion
    {
        readonly PostDbContext modeldb = new PostDbContext();

        public bool Guardar(Cancion obj)
        {
            modeldb.Cancion.Add(obj);
            modeldb.SaveChanges();
            return true;
        }

        public void Actualizar(Cancion obj)
        {
            var cancion = new Cancion { CveCancion = obj.CveCancion };
            modeldb.Cancion.Attach(cancion);
            cancion.NombreCancion = obj.NombreCancion;
            cancion.LetraCancion = obj.LetraCancion;
            cancion.CveartistaCancion = obj.CveartistaCancion;
            cancion.CvegeneroCancion = obj.CvegeneroCancion;
            modeldb.SaveChanges();
        }

        public void Eliminar(Cancion obj)
        {
            var cancion = new Cancion { CveCancion = obj.CveCancion };
            modeldb.Cancion.Attach(cancion);
            modeldb.Cancion.Remove(cancion);
            modeldb.SaveChanges();
        }

        public List<Cancion_Artista_Genero> BuscarNombreCancion(Cancion obj)
        {
            var query = (from t1 in modeldb.Cancion
                         join t2 in modeldb.Artista on t1.CveartistaCancion equals t2.CveArtista
                         join t3 in modeldb.Genero on t1.CvegeneroCancion equals t3.CveGenero
                         where t1.NombreCancion.Contains(obj.NombreCancion)
                         select new Cancion_Artista_Genero
                         {
                             ClaveCancion = t1.CveCancion,
                             Artista = t2.NombreArtista,
                             Cancion = t1.NombreCancion,
                             Genero = t3.NombreGenero,
                             Letra = t1.LetraCancion
                         }).ToList();
            return query;
        }
    }
}
