using Microsoft.EntityFrameworkCore;
using SteamCopyCat.Data;
using SteamCopyCat.DTO;
using SteamCopyCat.Models;

namespace FastfoodCopyCat.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<DTO_Get_Category>> AddNewCategory(DTO_Get_Category category)
        {
            var serviceResponse = new ServiceResponse<DTO_Get_Category>();
            try
            {
                bool isCategoryFound = await _context.Categories.AnyAsync(c => c.Name.ToLower() == category.Name.ToLower());
                if (!isCategoryFound)
                {
                    await _context.Categories.AddAsync(new Category { Name = category.Name });
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = category;
                }
                else
                {
                    throw new Exception("Category name already exists");
                }
            }
            catch (Exception ex)
            {
              serviceResponse.Sucess = false;
              serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<string>> DeleteCategory(string name)
        {
            var serviceResponse = new ServiceResponse<string>();
            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
                if (category is null)
                {
                    throw new Exception($"Category {name} do not exists");
                }
                 _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                serviceResponse.Data = $"Deleted {name}";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DTO_Get_Category>>> GetAllCategories()
        {
            var serviceResponse = new ServiceResponse<List<DTO_Get_Category>>();

            try
            {
                var categories = await _context.Categories.ToListAsync();
                serviceResponse.Data = MapCategoriesToListDTO(categories);
            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<DTO_Get_Category>> GetCategoryByName(string name)
        {
            var serviceResponse = new ServiceResponse<DTO_Get_Category>();
            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
                if (category is null)
                {
                    throw new Exception($"Category {name} do not exists");
                }
              serviceResponse.Data = MapCategoryToDTO(category);
            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<DTO_Get_Category>> UpdateCategory(string name)
        {
            var serviceResponse = new ServiceResponse<DTO_Get_Category>();
            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
                if (category is null)
                {
                    throw new Exception($"Category {name} do not exists");
                }

                category.Name = name;
                await _context.SaveChangesAsync();
                serviceResponse.Data = MapCategoryToDTO(category);
            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        private List<DTO_Get_Category> MapCategoriesToListDTO(List<Category> categories)
        {
            var dtoCategories = categories.Select(
                c =>
                new DTO_Get_Category
                {
                    Name = c.Name
                }
                ).ToList();
            return dtoCategories;
        }
        private DTO_Get_Category MapCategoryToDTO(Category category)
        {
            return new DTO_Get_Category
            {
                Name = category.Name,
            };
        }
    }
}
