using CapaDato.Entidades;
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

        public void Actualizar(Genero obj)
        {
            var genero = new Genero { CveGenero = obj.CveGenero };
            modeldb.Genero.Attach(genero);
            genero.NombreGenero = obj.NombreGenero;
            modeldb.SaveChanges();
        }

        public void Eliminar(Genero obj)
        {
            var genero = new Genero { CveGenero = obj.CveGenero };
            modeldb.Genero.Attach(genero);
            modeldb.Genero.Remove(genero);
            modeldb.SaveChanges();
        }

        public List<Genero> MostrarDatos()
        {
            var query = (from g in modeldb.Genero
                         select g).OrderBy(x=>x.NombreGenero);
            return query.ToList();
        }

        public int NumeroRegistros()
        {
            int numeroRegistro = (from g in modeldb.Genero
                                  select g).Count();
            return numeroRegistro;
        }
        public List<Genero> Buscar(Genero obj)
        {
            var query = (from a in modeldb.Genero
                         where a.NombreGenero.Contains(obj.NombreGenero)
                         select a);

            return query.ToList();
        }

        public List<Cancion_Artista_Genero> BuscarNombreGenero(Genero obj)
        {
            var query = (from t1 in modeldb.Cancion
                         join t2 in modeldb.Artista on t1.CveartistaCancion equals t2.CveArtista
                         join t3 in modeldb.Genero on t1.CvegeneroCancion equals t3.CveGenero
                         where t3.NombreGenero.Contains(obj.NombreGenero)
                         select new Cancion_Artista_Genero
                         {
                             ClaveCancion = t1.CveCancion,
                             ClaveArtista = t2.CveArtista,
                             ClaveGenero = t3.CveGenero,
                             Artista = t2.NombreArtista,
                             Cancion = t1.NombreCancion,
                             Genero = t3.NombreGenero,
                             Letra = t1.LetraCancion
                         }).OrderBy(x=>x.Genero)
                         .ToList();
            return query;
        }

        public static List<string> AutoCompletarNombreGenero(string nombreGenero)
        {
            PostDbContext modeldb = new PostDbContext();
            var query = (from g in modeldb.Genero
                     where g.NombreGenero.Contains(nombreGenero)
                     select g.NombreGenero).OrderBy(x=>x);

            return query.ToList();
        }

        public List<Genero> PaginacionByDescGenero(int startIndex, int maxRows, string desc)
        {
            var resul = (from oc in modeldb.Genero where oc.NombreGenero.Contains(desc) select oc)
                .OrderBy(p => p.NombreGenero).
                Skip((startIndex - 1) * maxRows).Take(maxRows);

            return resul.ToList();
        }

        public int PaginacionCountGenero(string desc)
        {
            return modeldb.Genero.Count(p => p.NombreGenero.Contains(desc));
        }
    }
}
