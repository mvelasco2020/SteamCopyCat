﻿namespace SteamCopyCat.DTO
{
    public class DTO_Get_MenuItem
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Calories { get; set; } = 0;
        public DTO_Get_Category? Category { get; set; }
        public List<DTO_Get_Ingredient>? Ingredients { get; set; }
        public int? CategoryId { get; set; }
        public string Image { get; set; }
        public double Price { get; set; } = 1.00;

    }
}
