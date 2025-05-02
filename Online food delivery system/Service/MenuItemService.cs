using Online_food_delivery_system.Interface;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Service
{
    public class MenuItemService
    {
       
            private readonly IMenuItem _menuItemRepository;

            public MenuItemService(IMenuItem menuItemRepository)
            {
                _menuItemRepository = menuItemRepository;
            }

            public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
            {
                return await _menuItemRepository.GetAllAsync();
            }

            public async Task<MenuItem> GetMenuItemByIdAsync(int itemId)
            {
                return await _menuItemRepository.GetByIdAsync(itemId);
            }

            public async Task AddMenuItemAsync(MenuItem menuItem)
            {
                await _menuItemRepository.AddAsync(menuItem);
            }

            public async Task UpdateMenuItemAsync(MenuItem menuItem)
            {
                await _menuItemRepository.UpdateAsync(menuItem);
            }

            public async Task DeleteMenuItemAsync(int itemId)
            {
                await _menuItemRepository.DeleteAsync(itemId);
            }
        
    }

}

