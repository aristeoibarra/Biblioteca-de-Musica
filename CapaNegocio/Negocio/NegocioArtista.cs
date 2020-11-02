using CapaDato.Datos;
using CapaDato.Entidades;
using CapaDato.Models;
using System.Collections.Generic;

namespace CapaNegocio.Negocio
{
    public class NegocioArtista
    {
        readonly DatoArtista DatoArtista = new DatoArtista();
        public bool Guardar(EntidadArtista dat)
        {
            Artista obj = new Artista
            {
                CveArtista = dat.CveArtista,
                NombreArtista = dat.NombreArtista
            };
            return DatoArtista.Guardar(obj);
        }

        public List<Artista> MostrarDatos()
        {
            return DatoArtista.MostrarDatos();
        }
    }
}
