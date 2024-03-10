using Microsoft.AspNetCore.Mvc;
using SteamCopyCat.DTO;
using SteamCopyCat.Models;
using SteamCopyCat.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SteamCopyCat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }
        // GET: api/<MenuController>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<MenuItem>>> GetAll()
        {
            return Ok(await _menuItemService.GetAllMenuItems());
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<DTO_Get_MenuItem>>> GetMenuItem(int id)
        {
            return Ok(await _menuItemService.GetMenuItem(id));
        }

        // POST api/<MenuController>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<MenuItem>>> Post(MenuItem menuItem)
        {
            return Ok(await _menuItemService.AddMenuItem(menuItem));
        }

        // PUT api/<MenuController>/5
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<MenuItem>>> Edit(DTO_Update_MenuItem menuItem)
        {
            return Ok(await _menuItemService.UpdateMenuItem(menuItem));
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("Delete")]
        public async Task<ActionResult<ServiceResponse<List<MenuItem>>>> Delete(int id)
        {
            return Ok(await _menuItemService.DeleteMenuItem(id));
        }
    }
}
