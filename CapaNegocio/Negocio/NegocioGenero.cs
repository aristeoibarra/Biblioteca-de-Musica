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

        public List<Genero> MostrarDatos()
        {
            return datoGenero.MostrarDatos();
        }
    }
}
