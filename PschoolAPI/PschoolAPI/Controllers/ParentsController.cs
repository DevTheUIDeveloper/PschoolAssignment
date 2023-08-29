using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pschool.Business;
using Pschool.Business.Dto;

namespace PschoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly IParentService _parentService;
        public ParentsController(IParentService parentService)
        {
            _parentService = parentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() 
        {
            var parents = await _parentService.GetAllAsync();
            return Ok(parents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var parent = await _parentService.GetParentByIdAsync(id);
            if (parent == null)
                return NotFound();
            return Ok(parent);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ParentDto body)
        {
            var parent = await _parentService.CreateParentAsync(body);
            return Ok(parent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ParentDto body)
        {
            var updatedParent = await _parentService.UpdateParentAsync(id, body);
            if(updatedParent == null) 
                return NotFound();
            return Ok(updatedParent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isDeleted = await _parentService.DeleteParentAsync(id);
            if (isDeleted)
                return Ok($"Parent with id: {id} deleted successfully");
            return BadRequest($"Parent with id: {id} deleted or not exists");
        }
    }
}
