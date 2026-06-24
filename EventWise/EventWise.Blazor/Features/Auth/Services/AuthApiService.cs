using System.Net.Http.Json;
using EventWise.Application.DTOs.Auth;

namespace EventWise.Blazor.Features.Auth.Services;

public class AuthApiService
{
    private readonly HttpClient _httpClient;

    public AuthApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
    {
        var response = await _httpClient
            .PostAsJsonAsync("api/auth/login", dto);

        if (response.IsSuccessStatusCode)
            return await response.Content
                .ReadFromJsonAsync<AuthResponseDto>();

        return null;
    }

    public async Task<AuthResponseDto?> RegisterAsync(RegisterDto dto)
    {
        var response = await _httpClient
            .PostAsJsonAsync("api/auth/register", dto);

        if (response.IsSuccessStatusCode)
            return await response.Content
                .ReadFromJsonAsync<AuthResponseDto>();

        return null;
    }
}