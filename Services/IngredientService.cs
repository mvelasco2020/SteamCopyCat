using Microsoft.EntityFrameworkCore;
using SteamCopyCat.Data;
using SteamCopyCat.DTO;
using SteamCopyCat.Models;

namespace FastfoodCopyCat.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly ApplicationDbContext _context;

        public IngredientService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<DTO_Get_Ingredient>> AddIngredient(DTO_Get_Ingredient ingredient)
        {
            var serviceResponse = new ServiceResponse<DTO_Get_Ingredient>();
            try
            {
                bool isIngredientExists = await _context
                                .Ingredients
                                .AnyAsync(i =>
                                i.Name.ToLower() == ingredient.Name.ToLower());
                if (isIngredientExists)
                {
                    throw new Exception($"Ingredient with the name of {ingredient.Name} already exists.");
                }

                await _context.Ingredients.AddAsync(new Ingredient()
                {
                    Name = ingredient.Name,
                    Image = ingredient.Image,
                });

                await _context.SaveChangesAsync();
                serviceResponse.Data = ingredient;
            }
            catch (Exception ex )
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<string>> Delete(string name)
        {
            var serviceResponse = new ServiceResponse<string>();
            try
            {
                 var ingredient = await _context
                                .Ingredients
                                .FirstOrDefaultAsync(i => i.Name.ToLower() == name.ToLower());

                if (ingredient is null)
                {
                    throw new Exception($"Ingredient with the name of {ingredient.Name} was not found.");
                }

                 _context.Ingredients.Remove(ingredient);
                await _context.SaveChangesAsync();
                serviceResponse.Data = $"Ingredient {name} has been deleted";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DTO_Get_Ingredient>>> GetAllIngredients()
        {
            var serviceResponse = new ServiceResponse<List<DTO_Get_Ingredient>>();
            try
            {
                var ingredients = await _context.Ingredients.ToListAsync();

                var newList = ingredients.Select(MapIngredientToDTO).ToList();
               serviceResponse.Data= newList;
            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<DTO_Get_Ingredient>> GetIngredientByName(string name)
        {
            var serviceResponse = new ServiceResponse<DTO_Get_Ingredient>();
            try
            {
                var ingredient = await _context
                               .Ingredients
                               .FirstOrDefaultAsync(i => i.Name.ToLower() == name.ToLower());

                if (ingredient is null)
                {
                    throw new Exception($"Ingredient with the name of {ingredient.Name} was not found.");
                }

               
                serviceResponse.Data = MapIngredientToDTO(ingredient);
            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<DTO_Get_Ingredient>> UpdateIngredient(DTO_Get_Ingredient ingredient)
        {
            var serviceResponse = new ServiceResponse<DTO_Get_Ingredient>();
            try
            {
                var currentIngredient = await _context
                                            .Ingredients
                                            .FirstOrDefaultAsync(i => 
                                                i.Name.ToLower() == ingredient.Name.ToLower());

                if (ingredient is null)
                {
                    throw new Exception($"Ingredient with the name of {ingredient.Name} was not found.");
                }

                currentIngredient.Name = ingredient.Name;
                currentIngredient.Image = ingredient.Image;
                await _context.SaveChangesAsync();

                serviceResponse.Data = MapIngredientToDTO(currentIngredient);
            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }


        private DTO_Get_Ingredient MapIngredientToDTO(Ingredient ingredient)
        {
            return new DTO_Get_Ingredient
            {
                Name = ingredient.Name,
                Image = ingredient.Image,
                MenuItems = ingredient.MenuItems.Select(m => new DTO_Get_MenuItem
                {
                    Id = m.Id,
                    Name = m.Name,
                    Image = m.Image,
                    Calories = m.Calories,
                    Price = m.Price,
                }).ToList(),
            };
        }
    }
}
