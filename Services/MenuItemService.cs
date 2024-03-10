using Microsoft.EntityFrameworkCore;
using SteamCopyCat.Data;
using SteamCopyCat.DTO;
using SteamCopyCat.Models;
using System.Linq;

namespace SteamCopyCat.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public MenuItemService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<ServiceResponse<DTO_Get_MenuItem>> AddMenuItem(DTO_Get_MenuItem menuItem)
        {
            var serviceResponse = new ServiceResponse<DTO_Get_MenuItem>();
            try
            {
                Category category = await _applicationDbContext
                                            .Categories
                                            .FirstOrDefaultAsync(c => 
                                                c.Name.ToLower() == menuItem.Category.Name.ToLower());

                List<Ingredient> ingredients = await _applicationDbContext
                                                        .Ingredients
                                                        .Where(i => 
                                                            menuItem
                                                            .Ingredients
                                                            .Select(m => m.Name.ToLower())
                                                            .ToList()
                                                            .Contains(i.Name.ToLower()))
                                                        .ToListAsync();

                MenuItem newItem = new MenuItem
                {
                    Name = menuItem.Name,
                    Calories = menuItem.Calories,
                    Description = menuItem.Description,
                    Category = category,
                    CategoryId = category.Id,
                    Ingredients = ingredients,
                    Price = menuItem.Price,
                    Image = menuItem.Image,
                };

                _applicationDbContext.MenuItems.Add(newItem);
                await _applicationDbContext.SaveChangesAsync();


                serviceResponse.Data = MapMenuItemToDTO(newItem);

            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DTO_Get_MenuItem>>> DeleteMenuItem(int Id)
        {
            var serviceResponse = new ServiceResponse<List<DTO_Get_MenuItem>>();
            try
            {
                var item = await _applicationDbContext.MenuItems.FirstOrDefaultAsync(m => m.Id == Id);

                if (item is not null)
                {
                    _applicationDbContext.MenuItems.Remove(item);
                    await _applicationDbContext.SaveChangesAsync();
                    
                    var menuItems = _applicationDbContext
                                    .MenuItems
                                    .Include(m => m.Category)
                                    .Include(m => m.Ingredients)
                                    .ToList();
                    serviceResponse.Data =  MapListOfMenuItemToDTO(menuItems);
                }
                else
                {
                    serviceResponse.Data = null;
                    throw new Exception("Item not found");
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DTO_Get_MenuItem>>> GetAllMenuItems()
        {
            var serviceResponse = new ServiceResponse<List<DTO_Get_MenuItem>>();
            try
            {
                var items = await _applicationDbContext
                                    .MenuItems
                                    .Include(m => m.Category)
                                    .Include(m => m.Ingredients)
                                    .ToListAsync();

                serviceResponse.Data = MapListOfMenuItemToDTO(items);
            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<DTO_Get_MenuItem>> GetMenuItem(int Id)
        {
            var serviceResponse = new ServiceResponse<DTO_Get_MenuItem>();
            try
            {

                var menuItem = await _applicationDbContext
                                        .MenuItems
                                        .Include(i => i.Category)
                                        .Include(i => i.Ingredients)
                                        .FirstAsync(m => m.Id == Id);
                if (menuItem is not null)
                {
                    DTO_Get_MenuItem returnItem = new DTO_Get_MenuItem();
                    returnItem.Name = menuItem.Name;
                    returnItem.Price = menuItem.Price;
                    returnItem.Calories = menuItem.Calories;
                    returnItem.CategoryId = menuItem.CategoryId;
                    returnItem.Category = new DTO_Get_Category { Name = menuItem.Category.Name };
                    returnItem.Description = menuItem.Description;
                    returnItem.Image = menuItem.Image;
                    returnItem.Ingredients = menuItem
                                        .Ingredients
                                        .Select(i => new DTO_Get_Ingredient {
                                            Name = i.Name
                                        })
                                        .ToList();
                    serviceResponse.Data = returnItem;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<DTO_Get_MenuItem>> UpdateMenuItem(DTO_Update_MenuItem item)
        {
            var serviceResponse = new ServiceResponse<DTO_Get_MenuItem>();
            try
            {
                var menuItem = await _applicationDbContext
                                        .MenuItems
                                        .Include(m => m.Category)
                                        .Include (m => m.Ingredients)
                                        .FirstAsync(m => m.Id == item.Id);
                if (menuItem != null)
                {
                    menuItem.Price = item.Price;
                    menuItem.Description = item.Description;
                    menuItem.Name = item.Name;
                    menuItem.Calories = item.Calories;
                    menuItem.CategoryId = item.CategoryId;
                    menuItem.Image = item.Image;
                    var ingredients = await _applicationDbContext
                                            .Ingredients
                                            .Where(m => item.IngredientIds.Contains(m.Id))
                                            .ToListAsync();
                    menuItem.Ingredients = ingredients;
                    await _applicationDbContext.SaveChangesAsync();


                    DTO_Get_MenuItem returnItem = MapMenuItemToDTO(menuItem);
                    serviceResponse.Data = returnItem;
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        private DTO_Get_MenuItem MapMenuItemToDTO(MenuItem menuItem)
        {
            List<DTO_Get_Ingredient> ingredients = menuItem
                            .Ingredients.Select( i => 
                                new DTO_Get_Ingredient {
                                    Name =  i.Name,
                                    Id = i.Id,
                                })
                            .ToList();

            DTO_Get_MenuItem menuItemDTO = new DTO_Get_MenuItem
            {
                Price = menuItem.Price,
                Description = menuItem.Description,
                Name = menuItem.Name,
                Calories = menuItem.Calories,
                CategoryId = menuItem.CategoryId,
                Category = new DTO_Get_Category
                {
                    Name = menuItem.Category.Name,
                },
                Ingredients = ingredients,
                Image = menuItem.Image,
            };
            return menuItemDTO;
}
        private List<DTO_Get_MenuItem> MapListOfMenuItemToDTO(List<MenuItem> items)
        {
            List<DTO_Get_MenuItem> menuItems = new List<DTO_Get_MenuItem>();

            items.ForEach(
                i => menuItems.Add(
                    new DTO_Get_MenuItem()
                    {
                        Image = i.Image,
                        Calories = i.Calories,
                        Category = new DTO_Get_Category { Name = i.Category.Name },
                        Description = i.Description,
                        CategoryId = i.Category.Id,
                        Name = i.Name,
                        Price = i.Price,
                        Ingredients = i.Ingredients.Select(j =>
                                        new DTO_Get_Ingredient { 
                                            Name = j.Name,
                                            Id = j.Id,
                                        })
                                        .ToList(),
                    }
                    )
                );

            return menuItems;
        }
    }
}
