using CapaDato.Datos;
using CapaDato.Entidades;
using CapaDato.Models;
using System.Collections.Generic;

namespace CapaNegocio.Negocio
{
    public class NegocioArtista
    {
        readonly DatoArtista datoArtista = new DatoArtista();

        public bool Guardar_Artista(EntidadArtista dat)
        {
            Artista obj = new Artista
            {
                NombreArtista = dat.NombreArtista
            };
            return datoArtista.Guardar_Artista(obj);
        }

        public void Actualizar_Artista(EntidadArtista dat)
        {
            Artista obj = new Artista
            {
                CveArtista = dat.CveArtista,
                NombreArtista = dat.NombreArtista
            };
            datoArtista.Actualizar_Artista(obj);
        }

        public void Eliminar_Artista(EntidadArtista dat)
        {
            Artista obj = new Artista
            {
                CveArtista = dat.CveArtista,
            };
            datoArtista.Eliminar_Artista(obj);
        }

        public List<Artista> MostrarDatos_Artista()
        {
            return datoArtista.MostrarDatos_Artista();
        }

        public int NumeroRegistros_Artista()
        {
            return datoArtista.NumeroRegistros_Artista();
        }

        public List<Artista> Buscar_Artista(EntidadArtista dat)
        {
            Artista obj = new Artista
            {
                NombreArtista = dat.NombreArtista,
            };
            return datoArtista.Buscar_Artista(obj);
        }

        public List<Cancion_Artista_Genero> BuscarNombre_Artista(EntidadArtista dat)
        {
            Artista obj = new Artista
            {
                NombreArtista = dat.NombreArtista,
            };
            return datoArtista.BuscarNombre_Artista(obj);
        }

        public static List<string> AutoCompletarNombre_Artista(string nombreArtista)
        {
            return DatoArtista.AutoCompletarNombre_Artista(nombreArtista);
        }

        public List<Artista> PaginacionByDesc_Artista(int index, int maxRows, string desc)
        {
            return datoArtista.PaginacionByDesc_Artista(index, maxRows, desc);
        }

        public int PaginacionCount_Artista(string desc)
        {
            return datoArtista.PaginacionCount_Artista(desc);
        }
    }
}
