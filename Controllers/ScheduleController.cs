using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservaInteligente.Models.DTOs;
using ReservaInteligente.Services;

namespace ReservaInteligente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleService _scheduleService;
        public ScheduleController(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleResponseDTO>>> GetAllSchedules()
        {
            var schedules = await _scheduleService.GetAllSchedulesAsync();
            if (schedules == null)
            {
                return NotFound();
            }
            return Ok(schedules);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleResponseDTO>> GetSchedule(int id)
        {
            var schedule = await _scheduleService.GetScheduleAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return Ok(schedule);
        }
        [HttpPost]
        public async Task<ActionResult<ScheduleResponseDTO>> CreateSchedule([FromBody] ScheduleRequestDTO scheduleRequest)
        {
            var schedule = await _scheduleService.CreateScheduleAsync(scheduleRequest);
            if (schedule == null)
            {
                return NotFound();
            }
            return Ok(schedule);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ScheduleResponseDTO>> UpdateSchedule(int id, [FromBody] ScheduleRequestDTO scheduleRequest)
        {
            var schedule = await _scheduleService.UpdateScheduleAsync(id, scheduleRequest);
            if (schedule == null)
            {
                return NotFound();
            }
            return Ok(schedule);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteSchedule(int id)
        {
            var result = await _scheduleService.DeleteScheduleAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok("Horario eliminado");
        }
    }
}
