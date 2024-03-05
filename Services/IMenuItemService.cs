using SteamCopyCat.Models;

namespace SteamCopyCat.Services
{
    public interface IMenuItemService
    {

        Task<ServiceResponse<MenuItem>> GetMenuItem(int Id);
        Task<ServiceResponse<List<MenuItem>>> GetAllMenuItems();
        Task<ServiceResponse<MenuItem>> AddMenuItem(MenuItem menuItem);

        Task<ServiceResponse<MenuItem>> UpdateMenuItem(MenuItem menuItem);

        Task<ServiceResponse<List<MenuItem>>> DeleteMenuItem(int Id);
    }
}
