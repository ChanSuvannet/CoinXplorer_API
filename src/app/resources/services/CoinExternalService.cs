using System.Text.Json;
using CoinXplorer_API.DTOs;

namespace CoinXplorer_API.Services
{
    public class CoinExternalService
    {
        private readonly HttpClient _httpClient;

        public CoinExternalService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            // Set a default base address for the HttpClient
            if (!_httpClient.DefaultRequestHeaders.UserAgent.Any())
            {
                _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("CoinXplorerApp/1.0 (+https://yourdomain.com)");
            }
        }

        public async Task<IEnumerable<CoinResponseDto>> GetLiveCoinsAsync()
        {
            var url = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var coins = JsonSerializer.Deserialize<List<CoinResponseDto>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return coins ?? new List<CoinResponseDto>();
        }
    }
}
