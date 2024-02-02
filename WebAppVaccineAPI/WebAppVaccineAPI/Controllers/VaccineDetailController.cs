using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppVaccineAPI.Models;

namespace WebAppVaccineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineDetailController : ControllerBase
    {
        private readonly VaccineManagementDbContext _vaccine;

        public VaccineDetailController(VaccineManagementDbContext vaccine)
        {
            _vaccine = vaccine;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccineDetail>>> GetVaccineDetail()
        {
            if (_vaccine.VaccineDetails == null)
            {
                return NotFound();
            }
            return await _vaccine.VaccineDetails.ToListAsync();

        }

        [HttpGet("{name}")]
        public async Task<ActionResult<VaccineDetail>> GetVaccineDetail(String name)
        {
            if (_vaccine.VaccineDetails == null)
            {
                return NotFound();
            }
            var vaccine = await _vaccine.VaccineDetails.FindAsync(name);
            if (vaccine == null)
            {
                return NotFound();
            }
            return vaccine;

        }

        [HttpPost]
        public async Task<ActionResult<VaccineDetail>> PostVaccineDetail(VaccineDetail vaccine)
        {
            _vaccine.VaccineDetails.Add(vaccine);
            await _vaccine.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVaccineDetail), new { id = vaccine.VaccineName }, vaccine);

        }
        [HttpPut]
        public async Task<IActionResult> PutVaccineDetail(String name, VaccineDetail vaccine)
        {
            if (name != vaccine.VaccineName)
            {
                return BadRequest();
            }
            _vaccine.Entry(vaccine).State = EntityState.Modified;
            try
            {
                await _vaccine.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!VaccineDetailAvailable(name))
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
        private bool VaccineDetailAvailable(String name)
        {
            return (_vaccine.VaccineDetails?.Any(x => x.VaccineName == name)).GetValueOrDefault();
        }
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteVaccineDetail(String name)
        {
            if (_vaccine.VaccineDetails == null)
            {
                return NotFound();
            }

            var vaccine = await _vaccine.VaccineDetails.FindAsync(name);
            if (vaccine == null)
            {
                return NotFound();
            }
            _vaccine.VaccineDetails.Remove(vaccine);
            await _vaccine.SaveChangesAsync();
            return Ok();
        }
    }
}
