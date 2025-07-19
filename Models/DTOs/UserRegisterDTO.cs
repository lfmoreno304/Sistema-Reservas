
using System.ComponentModel.DataAnnotations;

namespace ReservaInteligente.Models.DTOs;

public class UserRegisterDTO
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(6)]
    public string Password { get; set; }
    [Required]
    public int RoleId { get; set; }
}
