namespace SteamCopyCat.DTO
{
    public class DTO_Get_Ingredient
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public List<DTO_Get_MenuItem>? MenuItems { get; set; } 
    }
}
