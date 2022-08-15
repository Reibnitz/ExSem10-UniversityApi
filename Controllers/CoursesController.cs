using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Context;
using University.Mock;
using University.Models;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private UniversityContext _universityContext;
        private readonly ILogger<UniversityContext> _logger;

        public CoursesController(UniversityContext universityContext, ILogger<UniversityContext> logger)
        {
            _universityContext = universityContext;
            _logger = logger;
        }

        /// <summary>
        /// Busca e retorna a lista de Disciplinas do banco de dados
        /// </summary>
        /// <returns>Retorna uma lista de Disciplinas</returns>
        /// <response code="200">Retorna a lista encontrada</response>
        /// <response code="404">Não foi encontrada nenhuma Disciplina</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Course> courses = await _universityContext.Courses.ToListAsync();

                if (courses.Any() == false)
                    return NotFound();

                return Ok(courses);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Busca e retorna uma Disciplina específica através de seu Id
        /// </summary>
        /// <param name="id">Id da Disciplina</param>
        /// <returns>Retorna a Disciplina encontrada</returns>
        /// <response code="200">Retorna a Disciplina encontrada</response>
        /// <response code="404">Não foi encontrada nenhum Disciplina com este Id</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Course? course = await _universityContext.Courses.FirstOrDefaultAsync(c => c.Id == id);

                if (course == null)
                    return NotFound();

                return Ok(course);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Adiciona a Disciplina ao banco de dados
        /// </summary>
        /// <param name="student">Disciplina</param>
        /// <returns>Retorna Disciplina inserida com sucesso no banco de dados</returns>
        /// <response code="201">Disciplina adicionada com sucesso</response>
        /// <response code="500">Ocorreu um erro durante a execução</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Course course)
        {
            try
            {
                _universityContext.Courses.Add(course);
                await _universityContext.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { Id = course.Id }, course);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera informações sobre a Disciplina
        /// </summary>
        /// <param name="id">Id da Disciplina</param>
        /// <param name="student">Disciplina</param>
        /// <returns>Retorna Disciplina atualizada com sucesso</returns>
        /// <response code="204">Disciplina atualizada com sucesso</response>
        /// <response code="404">Não foi encontrada nenhuma Disciplina com este Id</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, [FromBody] Course course)
        {
            try
            {
                bool courseExists = await _universityContext.Courses.AnyAsync(c => c.Id == id);

                if (courseExists == false)
                    return NotFound();

                _universityContext.Courses.Update(course);
                await _universityContext.SaveChangesAsync();

                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Remove uma Disciplina do banco de dados
        /// </summary>
        /// <param name="id">Id da Disciplina</param>
        /// <returns>Retorna Disciplina removida com sucesso do banco de dados</returns>
        /// <response code="204">Disciplina removida com sucesso</response>
        /// <response code="404">Não foi encontrada nenhuma Disciplina com este Id</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Course? course = await _universityContext.Courses.FirstOrDefaultAsync(c => c.Id == id);

                if (course == null)
                    return NotFound();

                _universityContext.Courses.Remove(course);
                await _universityContext.SaveChangesAsync();

                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
