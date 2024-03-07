using Microsoft.EntityFrameworkCore;
using SteamCopyCat.Data;
using SteamCopyCat.Models;

namespace SteamCopyCat.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public MenuItemService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<ServiceResponse<MenuItem>> AddMenuItem(MenuItem menuItem)
        {
            var serviceResponse = new ServiceResponse<MenuItem>();
            try
            {
                _applicationDbContext.MenuItems.Add(menuItem);
                await _applicationDbContext.SaveChangesAsync();
                serviceResponse.Data = menuItem;

            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<MenuItem>>> DeleteMenuItem(int Id)
        {
            var serviceResponse = new ServiceResponse<List<MenuItem>>();
            try
            {
                var item = await _applicationDbContext.MenuItems.FirstOrDefaultAsync(m => m.Id == Id);

                if (item is not null)
                {
                    _applicationDbContext.MenuItems.Remove(item);
                    await _applicationDbContext.SaveChangesAsync();
                }
                else
                {
                    serviceResponse.Data = await _applicationDbContext.MenuItems.ToListAsync();
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<MenuItem>>> GetAllMenuItems()
        {
            var serviceResponse = new ServiceResponse<List<MenuItem>>();
            try
            {
                var items = await _applicationDbContext
                                    .MenuItems
                                    .Include(m => m.Category)
                                    .ToListAsync();
                serviceResponse.Data = await _applicationDbContext.MenuItems.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<MenuItem>> GetMenuItem(int Id)
        {
            var serviceResponse = new ServiceResponse<MenuItem>();
            try
            {
                serviceResponse.Data = await _applicationDbContext.MenuItems.FirstAsync(m => m.Id == Id);

            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<MenuItem>> UpdateMenuItem(MenuItem item)
        {
            var serviceResponse = new ServiceResponse<MenuItem>();
            try
            {
                var menuItem = await _applicationDbContext
                                        .MenuItems
                                        .FirstAsync(m => m.Id == item.Id);
                if (menuItem != null)
                {
                    _applicationDbContext.MenuItems.Update(item);
                    serviceResponse.Data = menuItem;
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
