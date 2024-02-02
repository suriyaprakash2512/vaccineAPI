using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppVaccineAPI.Models;

namespace WebAppVaccineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookForVaccineController : ControllerBase
    {
        private readonly VaccineManagementDbContext _booking;

        public BookForVaccineController(VaccineManagementDbContext booking)
        {
            _booking = booking;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookForVaccine>>> GetBookForVaccine()
        {
            if (_booking.BookForVaccines == null)
            {
                return NotFound();
            }
            return await _booking.BookForVaccines.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookForVaccine>> GetBookForVaccine(int id)
        {
            if (_booking.BookForVaccines == null)
            {
                return NotFound();
            }
            var booking = await _booking.BookForVaccines.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return booking;

        }

        [HttpPost]
        public async Task<ActionResult<BookForVaccine>> PostBookForVaccine(BookForVaccine booking)
        {
            _booking.BookForVaccines.Add(booking);

            await _booking.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookForVaccine), new { id = booking.BookingId }, booking);

        }
        [HttpPut]
        public async Task<IActionResult> PutBookForVaccine(int id, BookForVaccine booking)
        {
            if (id != booking.BookingId)
            {
                return BadRequest();
            }
            _booking.Entry(booking).State = EntityState.Modified;
            try
            {
                await _booking.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!BookForVaccineAvailable(id))
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
        private bool BookForVaccineAvailable(int id)
        {
            return (_booking.BookForVaccines?.Any(x => x.BookingId == id)).GetValueOrDefault();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookForVaccine(int id)
        {
            if (_booking.BookForVaccines == null)
            {
                return NotFound();
            }

            var booking = await _booking.BookForVaccines.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            _booking.BookForVaccines.Remove(booking);
            await _booking.SaveChangesAsync();
            return Ok();
        }
    }
}
