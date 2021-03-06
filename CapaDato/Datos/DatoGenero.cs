﻿using CapaDato.Entidades;
using CapaDato.Models;
using System.Collections.Generic;
using System.Linq;

namespace CapaDato.Datos
{
    public class DatoGenero
    {
        public bool Guardar_Genero(Genero obj)
        {
            using (var modeldb = new PostDbContext())
            {
                modeldb.Genero.Add(obj);
                modeldb.SaveChanges();
                return true;
            }             
        }

        public void Actualizar_Genero(Genero obj)
        {
            using (var modeldb = new PostDbContext())
            {
                var genero = new Genero { CveGenero = obj.CveGenero };
                modeldb.Genero.Attach(genero);
                genero.NombreGenero = obj.NombreGenero;
                modeldb.SaveChanges();
            }             
        }

        public void Eliminar_Genero(Genero obj)
        {
            using (var modeldb = new PostDbContext())
            {
                var genero = new Genero { CveGenero = obj.CveGenero };
                modeldb.Genero.Attach(genero);
                modeldb.Genero.Remove(genero);
                modeldb.SaveChanges();
            }               
        }

        public List<Genero> MostrarDatos_Genero()
        {
            using (var modeldb = new PostDbContext())
            {
                var query = (from g in modeldb.Genero
                             select g).OrderBy(x => x.NombreGenero);
                return query.ToList();
            }             
        }

        public int NumeroRegistros_Genero()
        {
            using (var modeldb = new PostDbContext())
            {
                int numeroRegistro = (from g in modeldb.Genero
                                      select g).Count();
                return numeroRegistro;
            }               
        }

        public List<Cancion_Artista_Genero> BuscarNombre_Genero(Genero obj)
        {
            using (var modeldb = new PostDbContext())
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
                             }).OrderBy(x => x.Genero)
                       .ToList();
                return query;
            }            
        }

        public List<Genero> Buscar_Genero(Genero obj)
        {
            using (var modeldb = new PostDbContext())
            {
                var query = (from a in modeldb.Genero
                             where a.NombreGenero.Contains(obj.NombreGenero)
                             select a);

                return query.ToList();
            }            
        }

        public static List<string> AutoCompletarNombre_Genero(string nombreGenero)
        {
            using (var modeldb = new PostDbContext())
            {
                var query = (from g in modeldb.Genero
                             where g.NombreGenero.Contains(nombreGenero)
                             select g.NombreGenero).OrderBy(x => x);

                return query.ToList();
            }            
        }

        public List<Genero> PaginacionByDesc_Genero(int startIndex, int maxRows, string desc)
        {
            using (var modeldb = new PostDbContext())
            {
                var resul = (from oc in modeldb.Genero where oc.NombreGenero.Contains(desc) select oc)
              .OrderBy(p => p.NombreGenero)
              .Skip((startIndex - 1) * maxRows).Take(maxRows);

                return resul.ToList();
            }            
        }

        public int PaginacionCount_Genero(string desc)
        {
            using (var modeldb = new PostDbContext())
            {
                return modeldb.Genero.Count(p => p.NombreGenero.Contains(desc));
            }
        }
    }
}
