using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Context;
using University.Mock;
using University.Models;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private UniversityContext _universityContext;
        private readonly ILogger<UniversityContext> _logger;

        public InstructorsController(UniversityContext universityContext, ILogger<UniversityContext> logger)
        {
            _universityContext = universityContext;
            _logger = logger;
        }

        /// <summary>
        /// Busca e retorna a lista de Instrutores do banco de dados
        /// </summary>
        /// <returns>Retorna uma lista de Instrutores</returns>
        /// <response code="200">Retorna a lista encontrada</response>
        /// <response code="404">Não foi encontrado nenhum Instrutor</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Instructor> instructors = await _universityContext.Instructors.ToListAsync();

                if (instructors.Any() == false)
                    return NotFound();

                return Ok(instructors);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Busca e retorna um Instrutor específico através de seu Id
        /// </summary>
        /// <param name="id">Id do Instrutor</param>
        /// <returns>Retorna o Instrutor encontrado</returns>
        /// <response code="200">Retorna o Instrutor encontrado</response>
        /// <response code="404">Não foi encontrado nenhum Instrutor com este Id</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Instructor? instructor = await _universityContext.Instructors.FirstOrDefaultAsync(professor => professor.Id == id);

                if (instructor == null)
                    return NotFound();

                return Ok(instructor);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Adiciona o Instrutor ao banco de dados
        /// </summary>
        /// <param name="instructor">Instrutor</param>
        /// <returns>Retorna Instrutor inserido com sucesso no banco de dados</returns>
        /// <response code="201">Instrutor adicionado com sucesso</response>
        /// <response code="500">Ocorreu um erro durante a execução</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Instructor instructor)
        {
            try
            {
                _universityContext.Instructors.Add(instructor);
                await _universityContext.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { Id = instructor.Id }, instructor);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera informações sobre o Instrutor
        /// </summary>
        /// <param name="id">Id do Instrutor</param>
        /// <param name="instructor">Instrutor</param>
        /// <returns>Retorna Instrutor atualizado com sucesso</returns>
        /// <response code="204">Instrutor atualizado com sucesso</response>
        /// <response code="404">Não foi encontrado nenhum Instrutor com este Id</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, [FromBody] Instructor instructor)
        {
            try
            {
                bool instructorExists = await _universityContext.Instructors.AnyAsync(i => i.Id == id);

                if (instructorExists == false)
                    return NotFound();

                _universityContext.Instructors.Update(instructor);
                await _universityContext.SaveChangesAsync();

                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Remove um Instrutor do banco de dados
        /// </summary>
        /// <param name="id">Id do Instrutor</param>
        /// <returns>Retorna Instrutor removido com sucesso do banco de dados</returns>
        /// <response code="204">Instrutor removido com sucesso</response>
        /// <response code="404">Não foi encontrado nenhum Instrutor com este Id</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Instructor? instructor = await _universityContext.Instructors.FirstOrDefaultAsync(professor => professor.Id == id);

                if (instructor == null)
                    return NotFound();

                _universityContext.Instructors.Remove(instructor);
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
