namespace ReservaInteligente.Models.DTOs;

public class ScheduleRequestDTO
{
    public int ServiceId { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool IsAvailable { get; set; }
}