using FastfoodCopyCat.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SteamCopyCat.DTO;
using SteamCopyCat.Models;

namespace FastfoodCopyCat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

     

        [HttpGet("{name}")]
        public async Task<ActionResult<ServiceResponse<DTO_Get_Ingredient>>> GetIngredient(string name)
        {
            return Ok(await _ingredientService.GetIngredientByName(name));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<DTO_Get_Ingredient>>> UpdateIngredient(DTO_Get_Ingredient Ingredient)
        {
            return Ok(await _ingredientService.UpdateIngredient(Ingredient));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<DTO_Get_Ingredient>>>> GetAll()
        {
            return Ok(await _ingredientService.GetAllIngredients());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<DTO_Get_Ingredient>>> AddIngredient(DTO_Get_Ingredient Ingredient)
        {
            return Ok(await _ingredientService.AddIngredient(Ingredient));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteIngredient(string Ingredient)
        {
            return Ok(await _ingredientService.Delete(Ingredient));
        }

    }
}
