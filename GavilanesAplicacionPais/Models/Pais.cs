using SQLite;

namespace AplicacionPais.Models
{
    public class Pais
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }  
        public string Nombre { get; set; }
        public string NombreBD { get; set; }
        public string EnlaceGoogleMaps { get; set; }
        public string Region { get; set; } 
         
    }
}
