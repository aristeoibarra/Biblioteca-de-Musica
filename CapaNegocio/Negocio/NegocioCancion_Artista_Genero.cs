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
            Cancion objCancion = new Cancion { NombreCancion = datCancion.NombreCancion };
            Artista objArtista = new Artista { NombreArtista = datArtista.NombreArtista };
            Genero objGenero = new Genero { NombreGenero = datGenero.NombreGenero };

            return datoCAG.BuscarTodo(objCancion, objArtista, objGenero);
        }

        public int NumeroRegistros()
        {
            int numeroRegistros = datoCAG.NumeroRegistros();
            return numeroRegistros;
        }

        public static List<string> AutoCompletar_Todo(string nombre)
        {
            return DatoCancion_Artista_Genero.AutoCompletar_Todo(nombre);
        }

        public static List<string> AutoCompletar_Cancion(string nombre)
        {
            return DatoCancion_Artista_Genero.AutoCompletar_Cancion(nombre);
        }

        public static List<string> AutoCompletar_Artista(string nombre)
        {
            return DatoCancion_Artista_Genero.AutoCompletar_Artista(nombre);
        }

        public static List<string> AutoCompletar_Genero(string nombre)
        {
            return DatoCancion_Artista_Genero.AutoCompletar_Genero(nombre);
        }
    }
}
