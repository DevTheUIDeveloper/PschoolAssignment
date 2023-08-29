using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pschool.Business.Dto;
using Pschool.Business;
using Pschool.DAL.Entities;

namespace PschoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpGet("{parentId}/GetStudentByParentId")]
        public async Task<IActionResult> GetStudentByParentIdAsync(int parentId)
        {
            var students = await _studentService.GetStudentByParentIdAsync(parentId);
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] StudentCreateUpdateDto body)
        {
            var student = await _studentService.CreateStudentAsync(body);
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] StudentCreateUpdateDto body)
        {
            var updatedStudent = await _studentService.UpdateStudentAsync(id, body);
            if (updatedStudent == null)
                return NotFound();
            return Ok(updatedStudent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isDeleted = await _studentService.DeleteStudentAsync(id);
            if (isDeleted)
                return Ok($"Student with id: {id} deleted successfully");
            return BadRequest($"Student with id: {id} deleted or not exists");
        }
    }
}
