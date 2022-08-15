using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Context;
using University.Models;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermGradesController : ControllerBase
    {
        private UniversityContext _universityContext;

        public TermGradesController(UniversityContext universityContext)
        {
            _universityContext = universityContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<TermGrade> termGrades = await _universityContext.TermGrades
                    .ToListAsync();

                if (termGrades.Any() == false)
                    return NotFound();

                return Ok(termGrades);
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
                TermGrade? team = await _universityContext.TermGrades
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
        public async Task<IActionResult> Post([FromBody] TermGrade termGrade)
        {
            try
            {
                _universityContext.TermGrades.Add(termGrade);
                await _universityContext.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { Id = termGrade.Id }, termGrade);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TermGrade termGrade)
        {
            try
            {
                bool termGradeIsValid = await _universityContext.TermGrades
                    .AnyAsync(termGrade => termGrade.Id == id);

                if (termGradeIsValid == false)
                    return NotFound();

                _universityContext.TermGrades.Update(termGrade);
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
                TermGrade? termGrade = await _universityContext.TermGrades
                    .FirstOrDefaultAsync(termGrade => termGrade.Id == id);

                if (termGrade == null)
                    return NotFound();

                _universityContext.TermGrades.Remove(termGrade);
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
