namespace ReservaInteligente.Models.DTOs;

public class AuthRequestDTO
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
