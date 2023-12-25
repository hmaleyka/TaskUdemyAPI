using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyAPI.DTOs.CategoryDtos;
using UdemyAPI.Services.Interfaces;

namespace UdemyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync ()
        {
            var categories = await _service.GetAllAsync();
            return StatusCode(StatusCodes.Status200OK, categories);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var categories = await _service.GetByIdAsync(id);
            return StatusCode(StatusCodes.Status200OK, categories);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateDto categoryCreateDto)
        {
            await _service.Create(categoryCreateDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromForm] CategoryUpdateDto categoryUpdateDto)
        {
            await _service.Update(id, categoryUpdateDto);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
