using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Context;
using University.Models;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private UniversityContext _universityContext;

        public TeamsController(UniversityContext universityContext)
        {
            _universityContext = universityContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Team> teams = await _universityContext.Teams
                    .Include(team => team.Course)
                    .Include(team => team.Instructor)
                    .ToListAsync();

                if (teams.Any() == false)
                    return NotFound();

                return Ok(teams);
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
                Team? team = await _universityContext.Teams
                    .Include(team => team.Course)
                    .Include(team => team.Instructor)
                    .FirstOrDefaultAsync(team => team.Id == id);

                if (team == null)
                    return NotFound();

                return Ok(team);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Team team)
        {
            try
            {
                _universityContext.Teams.Add(team);
                await _universityContext.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { Id = team.Id }, team);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Team team)
        {
            try
            {
                bool teamIsValid = await _universityContext.Teams.AnyAsync(team => team.Id == id);

                if (teamIsValid == false)
                    return NotFound();

                _universityContext.Teams.Update(team);
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
                Team? team = await _universityContext.Teams.FirstOrDefaultAsync(team => team.Id == id);

                if (team == null)
                    return NotFound();

                _universityContext.Teams.Remove(team);
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
