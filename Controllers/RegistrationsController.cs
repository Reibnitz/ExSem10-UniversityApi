using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using University.Context;
using University.Models;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private UniversityContext _universityContext;

        public RegistrationsController(UniversityContext universityContext)
        {
            _universityContext = universityContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Registration> registrations = await _universityContext.Registrations
                    .Include(registration => registration.Team)
                    .Include(registration => registration.Student)
                    .ToListAsync();

                if (registrations.Any() == false)
                    return NotFound();

                return Ok(registrations);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Registration? registration = await _universityContext.Registrations
                    .Include(registration => registration.Team)
                    .Include(registration => registration.Student)
                    .FirstOrDefaultAsync(registration => registration.Id == id);

                if (registration == null)
                    return NotFound();

                return Ok(registration);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Registration registration)
        {
            try
            {
                _universityContext.Registrations.Add(registration);
                await _universityContext.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { Id = registration.Id }, registration);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Registration registration)
        {
            try
            {
                bool registrationIsValid = await _universityContext.Registrations.AnyAsync(registration => registration.Id == id);

                if (registrationIsValid == false)
                    return NotFound();

                _universityContext.Registrations.Update(registration);
                await _universityContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Registration? registration = await _universityContext.Registrations.FirstOrDefaultAsync(registration => registration.Id == id);

                if (registration == null)
                    return NotFound();

                _universityContext.Registrations.Remove(registration);
                await _universityContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
