using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<ServiceResponse<MenuItem>>> GetMenuItem(int id)
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
