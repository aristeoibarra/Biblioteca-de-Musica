using CapaDato.Datos;
using CapaDato.Entidades;
using CapaDato.Models;
using System.Collections.Generic;

namespace CapaNegocio.Negocio
{
    public class NegocioGenero
    {
        readonly DatoGenero datoGenero = new DatoGenero();

        public bool Guardar_Genero(EntidadGenero dat)
        {
            Genero obj = new Genero
            {
                NombreGenero = dat.NombreGenero
            };
            return datoGenero.Guardar_Genero(obj);
        }

        public void Actualizar_Genero(EntidadGenero dat)
        {
            Genero obj = new Genero
            {
                CveGenero = dat.CveGenero,
                NombreGenero = dat.NombreGenero
            };
            datoGenero.Actualizar_Genero(obj);
        }

        public void Eliminar_Genero(EntidadGenero dat)
        {
            Genero obj = new Genero
            {
                CveGenero = dat.CveGenero,
            };
            datoGenero.Eliminar_Genero(obj);
        }

        public List<Genero> MostrarDatos_Genero()
        {
            return datoGenero.MostrarDatos_Genero();
        }

        public int NumeroRegistros_Genero()
        {
            return datoGenero.NumeroRegistros_Genero(); 
        }

        public List<Genero> Buscar_Genero(EntidadGenero dat)
        {
            Genero obj = new Genero
            {
                NombreGenero = dat.NombreGenero,
            };
            return datoGenero.Buscar_Genero(obj);
        }

        public List<Cancion_Artista_Genero> BuscarNombre_Genero(EntidadGenero dat)
        {
            Genero obj = new Genero
            {
                NombreGenero = dat.NombreGenero,
            };
            return datoGenero.BuscarNombre_Genero(obj);
        }

        public static List<string> AutoCompletarNombre_Genero(string nombreGenero)
        {
            return DatoGenero.AutoCompletarNombre_Genero(nombreGenero);
        }

        public List<Genero> PaginacionByDesc_Genero(int startIndex, int maxRows, string desc)
        {
            return datoGenero.PaginacionByDesc_Genero(startIndex, maxRows, desc);
        }

        public int PaginacionCount_Genero(string desc)
        {
            return datoGenero.PaginacionCount_Genero(desc);
        }
    }
}
