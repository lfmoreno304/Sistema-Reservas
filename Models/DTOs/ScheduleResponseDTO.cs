using ReservaInteligente.Models.Entities;

namespace ReservaInteligente.Models.DTOs;

public class ScheduleResponseDTO
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool IsAvailable { get; set; }
    public int ServiceId { get; set; }
    
}