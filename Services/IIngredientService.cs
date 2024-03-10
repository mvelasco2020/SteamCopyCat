using SteamCopyCat.DTO;
using SteamCopyCat.Models;

namespace FastfoodCopyCat.Services
{
    public interface IIngredientService
    {
       public Task<ServiceResponse<DTO_Get_Ingredient>> GetIngredientByName(string ingredient);
       public Task<ServiceResponse<List<DTO_Get_Ingredient>>> GetAllIngredients();
        public Task<ServiceResponse<DTO_Get_Ingredient>> AddIngredient(DTO_Get_Ingredient ingredient);
        public Task<ServiceResponse<DTO_Get_Ingredient>> UpdateIngredient(DTO_Get_Ingredient ingredient);
        public Task<ServiceResponse<string>> Delete(string name);
    }
}
