using CapaDato.Entidades;
using CapaDato.Models;
using System.Collections.Generic;
using System.Linq;

namespace CapaDato.Datos
{
    public class DatoCancion_Artista_Genero
    {
        readonly PostDbContext modeldb = new PostDbContext();

        public List<Cancion_Artista_Genero> MostrarDatos()
        {
            var query = (from t1 in modeldb.Cancion
                         join t2 in modeldb.Artista on t1.CveartistaCancion equals t2.CveArtista
                         join t3 in modeldb.Genero on t1.CvegeneroCancion equals t3.CveGenero
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


        public int NumeroRegistros()
        {
            int numRegistros = (from t1 in modeldb.Cancion
                                join t2 in modeldb.Artista on t1.CveartistaCancion equals t2.CveArtista
                                join t3 in modeldb.Genero on t1.CvegeneroCancion equals t3.CveGenero
                                select new Cancion_Artista_Genero
                                {
                                    ClaveCancion = t1.CveCancion,
                                    Artista = t2.NombreArtista,
                                    Cancion = t1.NombreCancion,
                                    Genero = t3.NombreGenero,
                                    Letra = t1.LetraCancion
                                }).Count();
            return numRegistros;
        }

        public List<Cancion_Artista_Genero> BuscarTodo(Cancion objCancion, Artista objArtista, Genero objGenero)
        {
            var query = (from t1 in modeldb.Cancion
                         join t2 in modeldb.Artista on t1.CveartistaCancion equals t2.CveArtista
                         join t3 in modeldb.Genero on t1.CvegeneroCancion equals t3.CveGenero
                         where t1.NombreCancion.Contains(objCancion.NombreCancion) ||
                               t2.NombreArtista.Contains(objArtista.NombreArtista) ||
                               t3.NombreGenero.Contains(objGenero.NombreGenero)
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
