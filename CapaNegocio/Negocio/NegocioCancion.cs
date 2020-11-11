using CapaDato.Datos;
using CapaDato.Entidades;
using CapaDato.Models;
using System.Collections.Generic;

namespace CapaNegocio.Negocio
{
    public class NegocioCancion
    {
        readonly DatoCancion datoCancion = new DatoCancion();

        public bool Guardar_Cancion(EntidadCancion dat)
        {
            Cancion obj = new Cancion
            {
                NombreCancion = dat.NombreCancion,
                LetraCancion = dat.LetraCancion,
                CveartistaCancion = dat.CveartistaCancion,
                CvegeneroCancion = dat.CvegeneroCancion
            };
            return datoCancion.Guardar_Cancion(obj);
        }

        public void Actualizar_Cancion(EntidadCancion dat)
        {
            Cancion obj = new Cancion
            {
                CveCancion = dat.CveCancion,
                NombreCancion = dat.NombreCancion,
                LetraCancion = dat.LetraCancion,
                CveartistaCancion = dat.CveartistaCancion,
                CvegeneroCancion = dat.CvegeneroCancion
            };
            datoCancion.Actualizar_Cancion(obj);
        }

        public void Eliminar_Cancion(EntidadCancion dat)
        {
            Cancion obj = new Cancion
            {
                CveCancion = dat.CveCancion
            };
            datoCancion.Eliminar_Cancion(obj);
        }

        public int NumeroRegistros_Cancion()
        {
            int numeroRegistros = datoCancion.NumeroRegistros_Cancion();
            return numeroRegistros;
        }

        public List<Cancion_Artista_Genero> BuscarNombre_Cancion (EntidadCancion dat)
        {
            Cancion obj = new Cancion
            {
                NombreCancion = dat.NombreCancion
            };
            return datoCancion.BuscarNombre_Cancion(obj);
        }

        public static List<string> AutoCompletarNombre_Cancion(string nombreCancion)
        {
            return DatoCancion.AutoCompletarNombre_Cancion(nombreCancion);
        }
    }
}
