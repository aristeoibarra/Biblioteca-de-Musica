using CapaDato.Datos;
using CapaDato.Entidades;
using CapaDato.Models;
using System.Collections.Generic;

namespace CapaNegocio.Negocio
{
    public class NegocioArtista
    {
        readonly DatoArtista datoArtista = new DatoArtista();

        public bool Guardar(EntidadArtista dat)
        {
            Artista obj = new Artista
            {
                CveArtista = dat.CveArtista,
                NombreArtista = dat.NombreArtista
            };
            return datoArtista.Guardar(obj);
        }

        public void Actualizar(EntidadArtista dat)
        {
            Artista obj = new Artista
            {
                CveArtista = dat.CveArtista,
                NombreArtista = dat.NombreArtista
            };
            datoArtista.Actualizar(obj);
        }

        public void Eliminar(EntidadArtista dat)
        {
            Artista obj = new Artista
            {
                CveArtista = dat.CveArtista,
            };
            datoArtista.Eliminar(obj);
        }

        public List<Artista> MostrarDatos()
        {
            return datoArtista.MostrarDatos();
        }
        public int NumeroRegistros()
        {
            int numeroRegistros = datoArtista.NumeroRegistros();
            return numeroRegistros;
        }
        public List<Artista> Buscar(EntidadArtista dat)
        {
            Artista obj = new Artista
            {
                NombreArtista = dat.NombreArtista,
            };
            return datoArtista.Buscar(obj);
        }

        public List<Cancion_Artista_Genero> BuscarNombreArtista(EntidadArtista dat)
        {
            Artista obj = new Artista
            {
                NombreArtista = dat.NombreArtista,
            };
            return datoArtista.BuscarNombreArtista(obj);
        }
    }
}
