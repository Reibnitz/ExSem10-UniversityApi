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
        /// Busca e retorna uma lista de alunos
        /// </summary>
        /// <returns>Retorna uma lista de alunos</returns>
        /// <response code="200">Retorna a lista encontrada</response>
        /// <response code="404">Não foi encontrado nenhum aluno</response>
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
        /// Busca e retorna um aluno específico através de seu Id
        /// </summary>
        /// <param name="id">Id do aluno</param>
        /// <returns>Retorna um aluno</returns>
        /// <response code="200">Retorna o aluno encontrado</response>
        /// <response code="404">Não foi encontrado nenhum aluno com este Id</response>
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
        /// Adiciona um novo aluno à lista
        /// </summary>
        /// <param name="student">Aluno</param>
        /// <returns></returns>
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

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

                return Ok();
            }
            catch
            {
                return NotFound();
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
                Student? mock = MockStudent.Students.FirstOrDefault(student => student.Id == id);

                if (mock == null)
                    return NotFound();

                MockStudent.Students.Remove(mock);

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
