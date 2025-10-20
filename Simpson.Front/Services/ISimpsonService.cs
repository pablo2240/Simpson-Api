using Simpson.Front.Models;

namespace Simpson.Front.Services
{
    public interface ISimpsonService
    {
        Task<ApiResponse> GetCharactersAsync(int page = 1);
        Task<Character> GetCharacterByIdAsync(int id);
    }
}