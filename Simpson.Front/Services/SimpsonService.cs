using System.Text.Json;
using Simpson.Front.Models;

namespace Simpson.Front.Services
{
    public class SimpsonService : ISimpsonService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public SimpsonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://thesimpsonsapi.com/");
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<ApiResponse> GetCharactersAsync(int page = 1)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/characters?page={page}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"API Response received: {content.Substring(0, Math.Min(200, content.Length))}...");

                    var apiResponse = JsonSerializer.Deserialize<ApiResponse>(content, _jsonOptions);

                    if (apiResponse?.Results != null)
                    {
                        Console.WriteLine($"Successfully loaded {apiResponse.Results.Count} characters");
                        return apiResponse;
                    }
                }

                Console.WriteLine($"HTTP Error: {response.StatusCode} - {response.ReasonPhrase}");
                return new ApiResponse();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return new ApiResponse();
            }
        }

        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/characters/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var character = JsonSerializer.Deserialize<Character>(content, _jsonOptions);
                    return character ?? new Character();
                }

                Console.WriteLine($"HTTP Error getting character {id}: {response.StatusCode}");
                return new Character();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception getting character {id}: {ex.Message}");
                return new Character();
            }
        }
    }
}