using CapaDato.Entidades;
using CapaDato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

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
                             ClaveArtista = t2.CveArtista,
                             ClaveGenero = t3.CveGenero,
                             Artista = t2.NombreArtista,
                             Cancion = t1.NombreCancion,
                             Genero = t3.NombreGenero,
                             Letra = t1.LetraCancion
                         }).OrderBy(x=>x.Artista).ToList();
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
                             ClaveArtista = t2.CveArtista,
                             ClaveGenero = t3.CveGenero,
                             Artista = t2.NombreArtista,
                             Cancion = t1.NombreCancion,
                             Genero = t3.NombreGenero,
                             Letra = t1.LetraCancion
                         }).OrderBy(x=>x.Artista).ToList();
            return query;
        }

        public static List<string> AutoCompletar_Todo(string nombre)
        {
            var query = (from c in AutoCompletar_Cancion(nombre)
                         .Union(AutoCompletar_Artista(nombre))
                         .Union(AutoCompletar_Genero(nombre))
                         select c);

            return query.OrderBy(x => x).ToList();
        }

        public static List<string> AutoCompletar_Cancion(string nombre)
        {
            PostDbContext modeldb = new PostDbContext();
            var query = (from c in modeldb.Cancion
                        join a in modeldb.Artista on c.CveartistaCancion equals a.CveArtista
                        join g in modeldb.Genero on c.CvegeneroCancion equals g.CveGenero
                        where c.NombreCancion.Contains(nombre)
                        select c.NombreCancion).OrderBy(x=>x);

            return query.ToList();
        }

        public static List<string> AutoCompletar_Artista(string nombre)
        {
            PostDbContext modeldb = new PostDbContext();
            var query = (from c in modeldb.Cancion
                         join a in modeldb.Artista on c.CveartistaCancion equals a.CveArtista
                         join g in modeldb.Genero on c.CvegeneroCancion equals g.CveGenero
                         where a.NombreArtista.Contains(nombre)
                         select a.NombreArtista).OrderBy(x=>x);

            return query.ToList();
        }

        public static List<string> AutoCompletar_Genero(string nombre)
        {
            PostDbContext modeldb = new PostDbContext();
            var query = (from c in modeldb.Cancion
                        join a in modeldb.Artista on c.CveartistaCancion equals a.CveArtista
                        join g in modeldb.Genero on c.CvegeneroCancion equals g.CveGenero
                        where g.NombreGenero.Contains(nombre)
                        select g.NombreGenero).OrderBy(x=>x);

            return query.ToList();
        }
    }
}
