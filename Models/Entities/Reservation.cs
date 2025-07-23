using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaInteligente.Models.Entities;

public class Reservation
{
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime ReservationDate { get; set; }
    [Required]
    [MaxLength(20)]
    public required String State { get; set; }
    [Required]
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User? User { get; set; }
    [Required]
    [ForeignKey("Schedules")]
    public int SchedulesId { get; set; }
    public Schedules? Schedules { get; set; }
}
