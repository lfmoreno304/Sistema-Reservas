namespace ReservaInteligente.Models.DTOs;

public class AuthResponse
{
    public string? Token { get; set; }
    public DateTime Expires { get; set; }
}
