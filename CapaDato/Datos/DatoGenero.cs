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
                         select g);
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
                             Artista = t2.NombreArtista,
                             Cancion = t1.NombreCancion,
                             Genero = t3.NombreGenero,
                             Letra = t1.LetraCancion
                         })
                         .ToList();
            return query;
        }
    }
}
