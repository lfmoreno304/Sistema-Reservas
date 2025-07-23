namespace ReservaInteligente.Models.DTOs;

public class AuthResponseDTO
{
    public string? Token { get; set; }
    public DateTime Expires { get; set; }
}
