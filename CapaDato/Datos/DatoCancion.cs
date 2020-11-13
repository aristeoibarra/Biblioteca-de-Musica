using CapaDato.Entidades;
using CapaDato.Models;
using System.Collections.Generic;
using System.Linq;

namespace CapaDato.Datos
{
    public class DatoCancion
    {
        public bool Guardar_Cancion(Cancion obj)
        {
            using (var modeldb = new PostDbContext())
            {
                modeldb.Cancion.Add(obj);
                modeldb.SaveChanges();
                return true;
            }              
        }

        public void Actualizar_Cancion(Cancion obj)
        {
            using (var modeldb = new PostDbContext())
            {
                var cancion = new Cancion { CveCancion = obj.CveCancion };
                modeldb.Cancion.Attach(cancion);
                cancion.NombreCancion = obj.NombreCancion;
                cancion.LetraCancion = obj.LetraCancion;
                cancion.CveartistaCancion = obj.CveartistaCancion;
                cancion.CvegeneroCancion = obj.CvegeneroCancion;
                modeldb.SaveChanges();
            }            
        }

        public void Eliminar_Cancion(Cancion obj)
        {
            using (var modeldb = new PostDbContext())
            {
                var cancion = new Cancion { CveCancion = obj.CveCancion };
                modeldb.Cancion.Attach(cancion);
                modeldb.Cancion.Remove(cancion);
                modeldb.SaveChanges();
            }            
        }

        public int NumeroRegistros_Cancion()
        {
            using (var modeldb = new PostDbContext())
            {
                int numeroRegistro = (from c in modeldb.Cancion
                                      select c).Count();
                return numeroRegistro;
            }
        }

        public List<Cancion_Artista_Genero> BuscarNombre_Cancion(Cancion obj)
        {
            using (var modeldb = new PostDbContext())
            {
                var query = (from t1 in modeldb.Cancion
                             join t2 in modeldb.Artista on t1.CveartistaCancion equals t2.CveArtista
                             join t3 in modeldb.Genero on t1.CvegeneroCancion equals t3.CveGenero
                             where t1.NombreCancion.Contains(obj.NombreCancion)
                             select new Cancion_Artista_Genero
                             {
                                 ClaveCancion = t1.CveCancion,
                                 ClaveArtista = t2.CveArtista,
                                 ClaveGenero = t3.CveGenero,
                                 Artista = t2.NombreArtista,
                                 Cancion = t1.NombreCancion,
                                 Genero = t3.NombreGenero,
                                 Letra = t1.LetraCancion
                             }).OrderBy(x => x.Cancion)
                      .ToList();
                return query;
            }             
        }

        public static List<string> AutoCompletarNombre_Cancion(string nombreCancion)
        {
            using (var modeldb = new PostDbContext())
            {
                var query = (from c in modeldb.Cancion
                             where c.NombreCancion.Contains(nombreCancion)
                             select c.NombreCancion);

                return query.ToList();
            }      
        }
    }
}
