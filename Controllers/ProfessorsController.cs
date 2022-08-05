using Microsoft.AspNetCore.Mvc;
using University.Mock;
using University.Models;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Professor> mockProfessors = MockProfessor.Professors;

                if (mockProfessors.Any() == false)
                    return NotFound();

                return Ok(mockProfessors);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Professor mockProfessor = MockProfessor.Professors.FirstOrDefault(professor => professor.Id == id);

                if (mockProfessor == null)
                    return NotFound();

                return Ok(mockProfessor);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Professor professor)
        {
            try
            {
                MockProfessor.Professors.Add(professor);

                return CreatedAtAction(nameof(Get), new { Id = professor.Id }, professor);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, [FromBody] Professor professor)
        {
            try
            {
                Professor mockProfessor = MockProfessor.Professors.FirstOrDefault(professor => professor.Id == id);

                if (mockProfessor == null)
                    return NotFound();

                mockProfessor.Id = professor.Id;
                mockProfessor.Name = professor.Name;
                mockProfessor.Email = professor.Email;
                mockProfessor.Phone = professor.Phone;
                mockProfessor.HourlyPay = professor.HourlyPay;
                mockProfessor.Certifications = professor.Certifications;

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Professor mockProfessor = MockProfessor.Professors.FirstOrDefault(professor => professor.Id == id);

                if (mockProfessor == null)
                    return NotFound();

                MockProfessor.Professors.Remove(mockProfessor);

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
