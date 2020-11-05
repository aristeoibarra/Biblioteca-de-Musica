using CapaDato.Datos;
using CapaDato.Entidades;
using CapaDato.Models;
using System.Collections.Generic;

namespace CapaNegocio.Negocio
{
    public class NegocioCancion_Artista_Genero
    {
        readonly DatoCancion_Artista_Genero datoCAG = new DatoCancion_Artista_Genero();

        public List<Cancion_Artista_Genero> MostrarDatos()
        {
            return datoCAG.MostrarDatos();
        }

        public List<Cancion_Artista_Genero> BuscarTodo(
         EntidadCancion datCancion, EntidadArtista datArtista, EntidadGenero datGenero)
        {
            Cancion objCancion = new Cancion();
            objCancion.NombreCancion = datCancion.NombreCancion;
            Artista objArtista = new Artista();
            objArtista.NombreArtista = datArtista.NombreArtista;
            Genero objGenero = new Genero();
            objGenero.NombreGenero = datGenero.NombreGenero;

            return datoCAG.BuscarTodo(objCancion, objArtista, objGenero);
        }
    }
}
