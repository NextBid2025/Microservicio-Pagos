using System.Net.Http;
using System.Threading.Tasks;
using Pago.Application.Interfaces;

namespace Pago.Infrastructure.Services
{
    public class SubastaService : ISubastaService
    {
        private readonly HttpClient _httpClient;

        public SubastaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ObtenerGanadorSubastaAsync(string subastaId)
        {
            var response = await _httpClient.GetAsync($"/api/pujas/{subastaId}/ganador");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            // Si el endpoint retorna solo el id como string plano
            return content.Trim('"'); // Por si viene entre comillas JSON
        }
    }
}