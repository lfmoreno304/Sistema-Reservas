
using System.ComponentModel.DataAnnotations;

namespace ReservaInteligente.Models.Entities;

public class Role
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    public ICollection<User>? Users { get; set; }
}
