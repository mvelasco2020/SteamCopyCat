using System.ComponentModel.DataAnnotations;

namespace SteamCopyCat.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Calories { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<Ingredient>? Ingredients { get; set; }

        public double Price { get; set; }
        public string Image { get; set; }
    }
}
