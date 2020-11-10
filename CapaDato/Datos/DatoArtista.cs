using CapaDato.Entidades;
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

        public void Actualizar(Artista obj)
        {
            var artista = new Artista { CveArtista = obj.CveArtista };
            modeldb.Artista.Attach(artista);
            artista.NombreArtista = obj.NombreArtista;
            modeldb.SaveChanges();
        }

        public void Eliminar(Artista obj)
        {
            var artista = new Artista { CveArtista = obj.CveArtista };
            modeldb.Artista.Attach(artista);
            modeldb.Artista.Remove(artista);
            modeldb.SaveChanges();
        }

        public List<Artista> MostrarDatos()
        {
            var query = (from a in modeldb.Artista
                         select a).OrderBy(x=>x.NombreArtista);

            return query.ToList();
        }

        public int NumeroRegistros()
        {
            int numeroRegistro = (from a in modeldb.Artista
                                  select a).Count();
            return numeroRegistro;
        }

        public List<Artista> Buscar(Artista obj)
        {
            var query = (from a in modeldb.Artista
                         where a.NombreArtista.Contains(obj.NombreArtista)
                         select a);

            return query.ToList();
        }

        public List<Cancion_Artista_Genero> BuscarNombreArtista(Artista obj)
        {
            var query = (from t1 in modeldb.Cancion
                         join t2 in modeldb.Artista on t1.CveartistaCancion equals t2.CveArtista
                         join t3 in modeldb.Genero on t1.CvegeneroCancion equals t3.CveGenero
                         where t2.NombreArtista.Contains(obj.NombreArtista)
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

        public static List<string> AutoCompletarNombreArtista(string nombreArtista)
        {
            PostDbContext modeldb = new PostDbContext();
            var query = (from a in modeldb.Artista
                     where a.NombreArtista.Contains(nombreArtista)
                     select a.NombreArtista).OrderBy(x=>x);

            return query.ToList();
        }

        public List<Artista> PaginacionByDescArtista(int startIndex, int maxRows, string desc)
        {
            var resul = (from oc in modeldb.Artista where oc.NombreArtista.Contains(desc) select oc)
                .OrderBy(p => p.NombreArtista).
                Skip((startIndex - 1) * maxRows).Take(maxRows);
            return resul.ToList();
        }

        public int PaginacionCountArtista(string desc)
        {
            return modeldb.Artista.Count(p => p.NombreArtista.Contains(desc));
        }
    }
}
