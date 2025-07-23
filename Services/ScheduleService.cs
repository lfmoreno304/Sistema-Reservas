using Microsoft.EntityFrameworkCore;
using ReservaInteligente.Data;
using ReservaInteligente.Models.DTOs;
using ReservaInteligente.Models.Entities;

namespace ReservaInteligente.Services;

public class ScheduleService
{
    private readonly ApplicationDbContext _context;
    public ScheduleService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ScheduleResponseDTO>> GetAllSchedulesAsync()
    {
        var schedules = await _context.Schedules.Include(s => s.Service)
        .Select(s => new ScheduleResponseDTO
        {
            Id = s.Id,
            Date = s.Date,
            StartTime = s.StartTime,
            EndTime = s.EndTime,
            IsAvailable = s.IsAvailable,
            ServiceId = s.Service!.Id
        }).ToListAsync();
        return schedules;
    }

    public async Task<ScheduleResponseDTO?> GetScheduleAsync(int id)
    {
        var schedule = await _context.Schedules.Include(s => s.Service)
        .FirstOrDefaultAsync(s => s.Id == id);
        if (schedule == null)
        {
            return null;
        }
        return new ScheduleResponseDTO
        {
            Id = schedule.Id,
            Date = schedule.Date,
            StartTime = schedule.StartTime,
            EndTime = schedule.EndTime,
            IsAvailable = schedule.IsAvailable,
            ServiceId = schedule.Service!.Id
        };
    }

    public async Task<ScheduleResponseDTO?> CreateScheduleAsync(ScheduleRequestDTO scheduleRequest)
    {
        var schedule = new Schedules
        {
            ServiceId = scheduleRequest.ServiceId,
            Date = scheduleRequest.Date,
            StartTime = scheduleRequest.StartTime,
            EndTime = scheduleRequest.EndTime,
            IsAvailable = false
        };
        _context.Schedules.Add(schedule);
        await _context.SaveChangesAsync();
      
        return await GetScheduleAsync(schedule.Id);
    }

    public async Task<ScheduleResponseDTO?> UpdateScheduleAsync(int id, ScheduleRequestDTO scheduleRequest)
    {
        var schedule = await _context.Schedules.FindAsync(id);
        if (schedule == null)
        {
            return null;
        }
        schedule.ServiceId = scheduleRequest.ServiceId;
        schedule.Date = scheduleRequest.Date;
        schedule.StartTime = scheduleRequest.StartTime;
        schedule.EndTime = scheduleRequest.EndTime;
        schedule.IsAvailable = scheduleRequest.IsAvailable;
        _context.Schedules.Update(schedule);
        await _context.SaveChangesAsync();
        return new ScheduleResponseDTO
        {
            Id = schedule.Id,
            Date = schedule.Date,
            StartTime = schedule.StartTime,
            EndTime = schedule.EndTime,
        };
    }
    
    public async Task<bool> DeleteScheduleAsync(int id)
    {
        var schedule = await _context.Schedules.FindAsync(id);
        if (schedule == null)
        {
            return false;
        }
        _context.Schedules.Remove(schedule);
        await _context.SaveChangesAsync();
        return true;
    }
}
