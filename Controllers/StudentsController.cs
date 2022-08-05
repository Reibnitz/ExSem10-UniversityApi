using Microsoft.AspNetCore.Mvc;
using University.Mock;
using University.Models;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
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
                IEnumerable<Student> students = MockStudent.Students;

                return students.Any() ? Ok(students) : NotFound();

            }
            catch
            {
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
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Student? mock = MockStudent.Students.FirstOrDefault(student => student.Id == id);

                return mock != null ? Ok(mock) : NotFound();
            }
            catch
            {
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
                MockStudent.Students.Add(student);

                return CreatedAtAction(nameof(Get), new { Id = student.Id }, student);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera informações sobre o Aluno
        /// </summary>
        /// <param name="id">Id do Aluno</param>
        /// <param name="student">Aluno</param>
        /// <returns>Retorna Aluno atualizado com sucesso</returns>
        /// <response code="204">Aluno atualizado com sucesso</response>
        /// <response code="404">Não foi encontrado nenhum Aluno com este Id</response>
        /// <response code="500">Ocorreu erro durante a execução</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, [FromBody] Student student)
        {
            try
            {
                Student? mock = MockStudent.Students.FirstOrDefault(student => student.Id == id);

                if (mock == null)
                    return NotFound();

                mock.Id = student.Id;
                mock.Name = student.Name;
                mock.CPF = student.CPF;
                mock.Email = student.Email;
                mock.Phone = student.Phone;
                mock.Birthday = student.Birthday;

                return NoContent();
            }
            catch
            {
                return NotFound();
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
                Student? mock = MockStudent.Students.FirstOrDefault(student => student.Id == id);

                if (mock == null)
                    return NotFound();

                MockStudent.Students.Remove(mock);

                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
