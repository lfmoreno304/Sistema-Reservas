
using System.ComponentModel.DataAnnotations;

namespace ReservaInteligente.Models.DTOs;

public class UserRegisterDTO
{
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public required string Email { get; set; }
    [Required]
    [MinLength(6)]
    public required string Password { get; set; }
    [Required]
    public int RoleId { get; set; }
}
