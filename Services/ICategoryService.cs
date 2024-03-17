using SteamCopyCat.DTO;
using SteamCopyCat.Models;

namespace FastfoodCopyCat.Services
{
    public interface ICategoryService
    {
        public Task<ServiceResponse<DTO_Get_Category>> GetCategoryByName(string name);
        public Task<ServiceResponse<DTO_Get_Category>> UpdateCategory(DTO_Get_Category category);
        public Task<ServiceResponse<List<DTO_Get_Category>>> GetAllCategories();

        public Task<ServiceResponse<DTO_Get_Category>> AddNewCategory(DTO_Get_Category name);
        public Task<ServiceResponse<string>> DeleteCategory(string name);
    }
}
