namespace SteamCopyCat.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }        
        public List<MenuItem> MenuItems { get; set; }
    }
}
