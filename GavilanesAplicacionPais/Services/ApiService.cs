using GavilanesAplicacionPais.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GavilanesAplicacionPais.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Pais> ObtenerPaisPorNombreAsync(string nombrePais)
        {
            try
            {
                var url = $"https://restcountries.com/v3.1/name/{nombrePais}?fields=name,region,flags,latlng,translations";
                var respuesta = await _httpClient.GetStringAsync(url);
                var paises = JsonConvert.DeserializeObject<List<Pais>>(respuesta);

                if (paises != null && paises.Count > 0)
                {
                    var pais = paises[0];
                    return new Pais
                    {
                        Nombre = pais.Nombre,
                        Region = pais.Region,
                        NombreBD = "JOHAOGAVILANES",
                        EnlaceGoogleMaps = $"https://www.google.com/maps/search/?q={pais.Nombre}"
                       
                    };
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
