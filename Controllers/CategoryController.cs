using FastfoodCopyCat.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SteamCopyCat.DTO;
using SteamCopyCat.Models;

namespace FastfoodCopyCat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _category;

        public CategoryController(ICategoryService category)
        {
            _category = category;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ServiceResponse<DTO_Get_Category>>> GetCategory(string name)
        {
            return Ok(await _category.GetCategoryByName(name));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<DTO_Get_Category>>> UpdateCategory(DTO_Get_Category category)
        {
            return Ok(await _category.UpdateCategory(category));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<DTO_Get_Category>>>> GetAll()
        {
            return Ok(await _category.GetAllCategories());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<DTO_Get_Category>>> AddCategory(DTO_Get_Category category)
        {
            return Ok(await _category.AddNewCategory(category));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteCategory(string category)
        {
            return Ok(await _category.DeleteCategory(category));
        }
    }
}
