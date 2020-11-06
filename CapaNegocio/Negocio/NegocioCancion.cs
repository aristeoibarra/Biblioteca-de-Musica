using CapaDato.Datos;
using CapaDato.Entidades;
using CapaDato.Models;
using System.Collections.Generic;

namespace CapaNegocio.Negocio
{
    public class NegocioCancion
    {
        readonly DatoCancion datoCancion = new DatoCancion();

        public bool Guardar(EntidadCancion dat)
        {
            Cancion obj = new Cancion
            {
                NombreCancion = dat.NombreCancion,
                LetraCancion = dat.LetraCancion,
                CveartistaCancion = dat.CveartistaCancion,
                CvegeneroCancion = dat.CvegeneroCancion
            };
            return datoCancion.Guardar(obj);
        }

        public void Actualizar(EntidadCancion dat)
        {
            Cancion obj = new Cancion
            {
                CveCancion = dat.CveCancion,
                NombreCancion = dat.NombreCancion,
                LetraCancion = dat.LetraCancion,
                CveartistaCancion = dat.CveartistaCancion,
                CvegeneroCancion = dat.CvegeneroCancion
            };
            datoCancion.Actualizar(obj);
        }

        public void Eliminar(EntidadCancion dat)
        {
            Cancion obj = new Cancion
            {
                CveCancion = dat.CveCancion
            };
            datoCancion.Eliminar(obj);
        }

        public int NumeroRegistros()
        {
            int numeroRegistros = datoCancion.NumeroRegistros();
            return numeroRegistros;
        }

        public List<Cancion_Artista_Genero> BuscarNombreCancion(EntidadCancion dat)
        {
            Cancion obj = new Cancion
            {
                NombreCancion = dat.NombreCancion
            };
            return datoCancion.BuscarNombreCancion(obj);
        }
    }
}
