namespace CapaDato.Models
{
    public partial class Cancion
    {
        public int CveCancion { get; set; }
        public string NombreCancion { get; set; }
        public string LetraCancion { get; set; }
        public int? CveartistaCancion { get; set; }
        public int? CvegeneroCancion { get; set; }

        public virtual Artista CveartistaCancionNavigation { get; set; }
        public virtual Genero CvegeneroCancionNavigation { get; set; }
    }
}
