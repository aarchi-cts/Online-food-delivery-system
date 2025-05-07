using Microsoft.AspNetCore.Mvc;
using Online_food_delivery_system.Models;
using Online_food_delivery_system.Service;

namespace Online_food_delivery_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly MenuItemService _menuItemService;

        public MenuItemController(MenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        // GET: api/MenuItem
        [HttpGet]
        public async Task<IActionResult> GetAllMenuItems()
        {
            var menuItems = await _menuItemService.GetAllMenuItemsAsync();
            return Ok(menuItems);
        }

        // GET: api/MenuItem/{id}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetMenuItemById(int id)
        //{
        //    var menuItem = await _menuItemService.GetMenuItemByIdAsync(id);
        //    if (menuItem == null)
        //        return NotFound("Menu item not found");
        //    return Ok(menuItem);
        //}

        //// POST: api/MenuItem
        //[HttpPost]
        //public async Task<IActionResult> AddMenuItem([FromBody] MenuItem menuItem)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    await _menuItemService.AddMenuItemAsync(menuItem);
        //    return CreatedAtAction(nameof(GetMenuItemById), new { id = menuItem.ItemID }, menuItem);
        //}

        //// PUT: api/MenuItem/{id}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateMenuItem(int id, [FromBody] MenuItem menuItem)
        //{
        //    if (id != menuItem.ItemID)
        //        return BadRequest("Menu item ID mismatch");

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var existingMenuItem = await _menuItemService.GetMenuItemByIdAsync(id);
        //    if (existingMenuItem == null)
        //        return NotFound("Menu item not found");

        //    await _menuItemService.UpdateMenuItemAsync(menuItem);
        //    return NoContent();
        //}

        //// DELETE: api/MenuItem/{id}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMenuItem(int id)
        //{
        //    var menuItem = await _menuItemService.GetMenuItemByIdAsync(id);
        //    if (menuItem == null)
        //        return NotFound("Menu item not found");

        //    await _menuItemService.DeleteMenuItemAsync(id);
        //    return NoContent();
        //}
    }
}
