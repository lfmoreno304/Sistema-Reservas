
using System.ComponentModel.DataAnnotations;

namespace ReservaInteligente.Models.Entities;

public class Services
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(100)]
    public string Description { get; set; }

    public ICollection<Schedules> Schedules { get; set; }
}
