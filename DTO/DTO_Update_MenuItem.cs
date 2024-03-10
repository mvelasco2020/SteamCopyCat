namespace SteamCopyCat.DTO
{
    public class DTO_Update_MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public int Calories { get; set; }
        public List<int> IngredientIds { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }

    }
}
