
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaInteligente.Models.Entities;

public class Schedules
{
    [Key]
    public int Id { get; set; }
    [Required]
    [ForeignKey("Service")]
    public int ServiceId { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public TimeSpan StartTime { get; set; }
    [Required]
    public TimeSpan EndTime { get; set; }

    public bool IsAvailable { get; set; } = false;
    public  Service? Service { get; set; }
    public ICollection<Reservation>? Reservations { get; set; }
}
