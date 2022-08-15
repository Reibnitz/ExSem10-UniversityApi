using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Context;
using University.Mock;
using University.Models;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private UniversityContext _universityContext;
        private readonly ILogger<UniversityContext> _logger;

        public StudentsController(UniversityContext universityContext, ILogger<UniversityContext> logger)
        {
            _universityContext = universityContext;
            _logger = logger;
        }

        /// <summary>
        /// Busca e retorna a lista de Alunos do banco de dados
        /// </summary>
        /// <returns>Retorna uma lista de Alunos</returns>
        /// <response code="200">Retorna a lista encontrada</response>
        /// <response code="404">Não foi encontrado nenhum Aluno</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Student> students = await _universityContext.Students.ToListAsync();

                _logger.LogInformation($"Controller: {nameof(StudentsController)} - Metodo: {nameof(Get)}");

                if (students.Any() == false)
                    return NotFound();

                return Ok(students);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Controller: {nameof(StudentsController)} - Metodo: {nameof(Get)}");

                return StatusCode(500);
            }        
        }

        /// <summary>
        /// Busca e retorna um Aluno específico através de seu Id
        /// </summary>
        /// <param name="id">Id do Aluno</param>
        /// <returns>Retorna o Aluno encontrado</returns>
        /// <response code="200">Retorna o Aluno encontrado</response>
        /// <response code="404">Não foi encontrado nenhum Aluno com este Id</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Student? student = await _universityContext.Students.FirstOrDefaultAsync(student => student.Id == id);

                _logger.LogInformation($"Controller: {nameof(StudentsController)} - Metodo: {nameof(GetById)}");

                if (student == null)
                    return NotFound();

                return Ok(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Controller: {nameof(StudentsController)} - Metodo: {nameof(GetById)}");

                return StatusCode(500);
            }
        }

        /// <summary>
        /// Adiciona o Aluno ao banco de dados
        /// </summary>
        /// <param name="student">Aluno</param>
        /// <returns>Retorna Aluno inserido com sucesso no banco de dados</returns>
        /// <response code="201">Aluno adicionado com sucesso</response>
        /// <response code="500">Ocorreu um erro durante a execução</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            try
            {
                _universityContext.Students.Add(student);
                await _universityContext.SaveChangesAsync();

                _logger.LogInformation($"Controller: {nameof(StudentsController)} - Metodo: {nameof(Post)}");

                return CreatedAtAction(nameof(Get), new { Id = student.Id }, student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Controller: {nameof(StudentsController)} - Metodo: {nameof(Post)}");

                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera informações sobre o Aluno
        /// </summary>
        /// <param name="id">Id do Aluno</param>
        /// <param name="newStudent">Aluno</param>
        /// <returns>Retorna Aluno atualizado com sucesso</returns>
        /// <response code="204">Aluno atualizado com sucesso</response>
        /// <response code="404">Não foi encontrado nenhum Aluno com este Id</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, [FromBody] Student newStudent)
        {
            try
            {
                //Student? oldStudent = await _universityContext.Students.FirstOrDefaultAsync(student => student.Id == id);
                // Não é possível alterar a entrada através de 'Update' (linha 125) usando o FirstOrDefault

                bool studentExists = await _universityContext.Students.AnyAsync(s => s.Id == id);

                _logger.LogInformation($"Controller: {nameof(StudentsController)} - Metodo: {nameof(Put)}");

                if (studentExists == false)
                {
                    return NotFound();
                }

                _universityContext.Students.Update(newStudent);
                await _universityContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Controller: {nameof(StudentsController)} - Metodo: {nameof(Put)}");

                return StatusCode(500);
            }
        }

        /// <summary>
        /// Remove um Aluno do banco de dados
        /// </summary>
        /// <param name="id">Id do Aluno</param>
        /// <returns>Retorna Aluno removido com sucesso do banco de dados</returns>
        /// <response code="204">Aluno removido com sucesso</response>
        /// <response code="404">Não foi encontrado nenhum Aluno com este Id</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Student? student = await _universityContext.Students.FirstOrDefaultAsync(student => student.Id == id);

                _logger.LogInformation($"Controller: {nameof(StudentsController)} - Metodo: {nameof(Delete)}");

                if (student == null)
                    return NotFound();

                _universityContext.Students.Remove(student);
                await _universityContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Controller: {nameof(StudentsController)} - Metodo: {nameof(Delete)}");

                return StatusCode(500);
            }
        }
    }
}
