using SteamCopyCat.Models;

namespace SteamCopyCat.Services
{
    public interface IMenuItemService
    {

        Task<ServiceResponse<MenuItem>> GetMenuItem(int Id);
        Task<ServiceResponse<List<MenuItem>>> GetAllMenuItems();
        Task<ServiceResponse<MenuItem>> AddMenuItem(int Id);

        Task<ServiceResponse<MenuItem>> UpdateMenuItem(int Id);

        Task<ServiceResponse<List<MenuItem>>> DeleteMenuItem(int Id);
    }
}
