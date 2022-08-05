using Microsoft.AspNetCore.Mvc;
using University.Mock;
using University.Models;

namespace University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Course> mockCourses = MockCourse.Courses;

                if (mockCourses.Any() == false)
                    return NotFound();

                return Ok(mockCourses);
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
                Course mockCourse = MockCourse.Courses.FirstOrDefault(course => course.Id == id);

                if (mockCourse == null)
                    return NotFound();

                return Ok(mockCourse);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Course course)
        {
            try
            {
                MockCourse.Courses.Add(course);

                return CreatedAtAction(nameof(Get), new { Id = course.Id }, course);
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
        public async Task<IActionResult> Put(int id, [FromBody] Course course)
        {
            try
            {
                Course mockCourse = MockCourse.Courses.FirstOrDefault(course => course.Id == id);

                if (mockCourse == null)
                    return NotFound();

                mockCourse.Id = course.Id;
                mockCourse.Name = course.Name;
                mockCourse.Requisite = course.Requisite;
                mockCourse.Workload = course.Workload;
                mockCourse.Cost = course.Cost;

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
                Course mockCourse = MockCourse.Courses.FirstOrDefault(course => course.Id == id);

                if (mockCourse == null)
                    return NotFound();

                MockCourse.Courses.Remove(mockCourse);

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
