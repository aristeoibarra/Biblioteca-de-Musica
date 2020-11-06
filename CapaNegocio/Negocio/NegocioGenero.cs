using CapaDato.Datos;
using CapaDato.Entidades;
using CapaDato.Models;
using System.Collections.Generic;

namespace CapaNegocio.Negocio
{
    public class NegocioGenero
    {
        readonly DatoGenero datoGenero = new DatoGenero();

        public bool Guardar(EntidadGenero dat)
        {
            Genero obj = new Genero
            {
                CveGenero = dat.CveGenero,
                NombreGenero = dat.NombreGenero
            };
            return datoGenero.Guardar(obj);
        }

        public void Actualizar(EntidadGenero dat)
        {
            Genero obj = new Genero
            {
                CveGenero = dat.CveGenero,
                NombreGenero = dat.NombreGenero
            };
            datoGenero.Actualizar(obj);
        }

        public void Eliminar(EntidadGenero dat)
        {
            Genero obj = new Genero
            {
                CveGenero = dat.CveGenero,
            };
            datoGenero.Eliminar(obj);
        }

        public List<Genero> MostrarDatos()
        {
            return datoGenero.MostrarDatos();
        }
        public List<Genero> Buscar(EntidadGenero dat)
        {
            Genero obj = new Genero
            {
                NombreGenero = dat.NombreGenero,
            };
            return datoGenero.Buscar(obj);
        }
        public int NumeroRegistros()
        {
            int numeroRegistros = datoGenero.NumeroRegistros();
            return numeroRegistros;
        }

        public List<Cancion_Artista_Genero> BuscarNombreGenero(EntidadGenero dat)
        {
            Genero obj = new Genero
            {
                NombreGenero = dat.NombreGenero,
            };
            return datoGenero.BuscarNombreGenero(obj);
        }
    }
}
