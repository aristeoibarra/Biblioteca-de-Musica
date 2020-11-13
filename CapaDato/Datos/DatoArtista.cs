using CapaDato.Entidades;
using CapaDato.Models;
using System.Collections.Generic;
using System.Linq;

namespace CapaDato.Datos
{
    public class DatoArtista
    {
        public bool Guardar_Artista(Artista obj)
        {
            using (var modeldb = new PostDbContext())
            {
                modeldb.Artista.Add(obj);
                modeldb.SaveChanges();
                return true;
            }          
        }

        public void Actualizar_Artista(Artista obj)
        {
            using (var modeldb = new PostDbContext())
            {
                var artista = new Artista { CveArtista = obj.CveArtista };
                modeldb.Artista.Attach(artista);
                artista.NombreArtista = obj.NombreArtista;
                modeldb.SaveChanges();
            }
        }

        public void Eliminar_Artista(Artista obj)
        {
            using (var modeldb = new PostDbContext())
            {
                var artista = new Artista { CveArtista = obj.CveArtista };
                modeldb.Artista.Attach(artista);
                modeldb.Artista.Remove(artista);
                modeldb.SaveChanges();
            }         
        }

        public List<Artista> MostrarDatos_Artista()
        {
            using (var modeldb = new PostDbContext())
            {
                var query = (from a in modeldb.Artista
                             select a).OrderBy(x => x.NombreArtista);

                return query.ToList();
            }
        }

        public int NumeroRegistros_Artista()
        {
            using (var modeldb = new PostDbContext())
            {

                int numeroRegistro = (from a in modeldb.Artista
                                      select a).Count();
                return numeroRegistro;
            }
        }

        public List<Cancion_Artista_Genero> BuscarNombre_Artista(Artista obj)
        {
            using (var modeldb = new PostDbContext())
            {
                var query = (from t1 in modeldb.Cancion
                             join t2 in modeldb.Artista on t1.CveartistaCancion equals t2.CveArtista
                             join t3 in modeldb.Genero on t1.CvegeneroCancion equals t3.CveGenero
                             where t2.NombreArtista.Contains(obj.NombreArtista)
                             select new Cancion_Artista_Genero
                             {
                                 ClaveCancion = t1.CveCancion,
                                 ClaveArtista = t2.CveArtista,
                                 ClaveGenero = t3.CveGenero,
                                 Artista = t2.NombreArtista,
                                 Cancion = t1.NombreCancion,
                                 Genero = t3.NombreGenero,
                                 Letra = t1.LetraCancion
                             }).OrderBy(x => x.Artista);

                return query.ToList();
            }
        }

        public List<Artista> Buscar_Artista(Artista obj)
        {
            using (var modeldb = new PostDbContext())
            {
                var query = (from a in modeldb.Artista
                             where a.NombreArtista.Contains(obj.NombreArtista)
                             select a);

                return query.ToList();
            }             
        }

        public static List<string> AutoCompletarNombre_Artista(string nombreArtista)
        {
            using (var modeldb = new PostDbContext())
            {
                var query = (from a in modeldb.Artista
                             where a.NombreArtista.Contains(nombreArtista)
                             select a.NombreArtista).OrderBy(x => x);

                return query.ToList();
            }            
        }

        public List<Artista> PaginacionByDesc_Artista(int index, int maxRows, string desc)
        {
            using (var modeldb = new PostDbContext())
            {
                var resul = (from oc in modeldb.Artista where oc.NombreArtista.Contains(desc) select oc)
               .OrderBy(p => p.NombreArtista).
                Skip((index - 1) * maxRows).Take(maxRows);
                return resul.ToList();
            }             
        }

        public int PaginacionCount_Artista(string desc)
        {
            using (var modeldb = new PostDbContext())
            {
                return modeldb.Artista.Count(p => p.NombreArtista.Contains(desc));

            }
        }
    }
}
