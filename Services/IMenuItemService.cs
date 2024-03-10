using SteamCopyCat.DTO;
using SteamCopyCat.Models;

namespace SteamCopyCat.Services
{
    public interface IMenuItemService
    {

        Task<ServiceResponse<DTO_Get_MenuItem>> GetMenuItem(int Id);
        Task<ServiceResponse<List<DTO_Get_MenuItem>>> GetAllMenuItems();
        Task<ServiceResponse<DTO_Get_MenuItem>> AddMenuItem(DTO_Get_MenuItem menuItem);

        Task<ServiceResponse<DTO_Get_MenuItem>> UpdateMenuItem(DTO_Update_MenuItem menuItem);

        Task<ServiceResponse<List<DTO_Get_MenuItem>>> DeleteMenuItem(int Id);
    }
}
