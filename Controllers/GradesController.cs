using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Context;
using University.Models;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private UniversityContext _universityContext;

        public GradesController(UniversityContext universityContext)
        {
            _universityContext = universityContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Grade> grades = await _universityContext.Grades
                    .Include(grade => grade.Registration)
                    .Include(grade => grade.TermGrade)
                    .ToListAsync();

                if (grades.Any() == false)
                    return NotFound();

                return Ok(grades);
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
                Grade? grade = await _universityContext.Grades
                    .Include(grade => grade.Registration)
                    .Include(grade => grade.TermGrade)
                    .FirstOrDefaultAsync(grade => grade.Id == id);

                if (grade == null)
                    return NotFound();

                return Ok(grade);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Grade grade)
        {
            try
            {
                _universityContext.Grades.Add(grade);
                await _universityContext.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { Id = grade.Id }, grade);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Grade grade)
        {
            try
            {
                bool gradeIsValid = await _universityContext.Grades.AnyAsync(grade => grade.Id == id);

                if (gradeIsValid == false)
                    return NotFound();

                _universityContext.Grades.Update(grade);
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
                Grade? grade = await _universityContext.Grades.FirstOrDefaultAsync(grade => grade.Id == id);

                if (grade == null)
                    return NotFound();

                _universityContext.Grades.Remove(grade);
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
