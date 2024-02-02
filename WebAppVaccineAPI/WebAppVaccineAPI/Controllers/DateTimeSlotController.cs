using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppVaccineAPI.Models;

namespace WebAppVaccineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateTimeSlotController : ControllerBase
    {
        private readonly VaccineManagementDbContext _datetime;

        public DateTimeSlotController(VaccineManagementDbContext datetime)
        {
            _datetime = datetime;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DateTimeSlot>>> GetDateTimeSlot()
        {
            if (_datetime.DateTimeSlots == null)
            {
                return NotFound();
            }
            return await _datetime.DateTimeSlots.ToListAsync();

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<DateTimeSlot>> GetDateTimeSlot(int id)
        {
            if (_datetime.DateTimeSlots == null)
            {
                return NotFound();
            }
            var datetime = await _datetime.DateTimeSlots.FindAsync(id);
            if (datetime == null)
            {
                return NotFound();
            }
            return datetime;

        }

        [HttpPost]
        public async Task<ActionResult<DateTimeSlot>> Postdatetime(DateTimeSlot datetime)
        {
            _datetime.DateTimeSlots.Add(datetime);
            await _datetime.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDateTimeSlot), new { datetiming = datetime.DatetimeId }, datetime);

        }
        [HttpPut]
        public async Task<IActionResult> PutDateTimeSlot(int id, DateTimeSlot datetime)
        {
            if (id != datetime.DatetimeId)
            {
                return BadRequest();
            }
            _datetime.Entry(datetime).State = EntityState.Modified;
            try
            {
                await _datetime.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!DateTimeSlotAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }
        private bool DateTimeSlotAvailable(int id)
        {
            return (_datetime.DateTimeSlots?.Any(x => x.DatetimeId == id)).GetValueOrDefault();
        }
        [HttpDelete("{datetiming}")]
        public async Task<IActionResult> DeleteDateTimeSlot(int id)
        {
            if (_datetime.DateTimeSlots == null)
            {
                return NotFound();
            }

            var datetime = await _datetime.DateTimeSlots.FindAsync(id);
            if (datetime == null)
            {
                return NotFound();
            }
            _datetime.DateTimeSlots.Remove(datetime);
            await _datetime.SaveChangesAsync();
            return Ok();
        }
    }
}
