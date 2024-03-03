using System.ComponentModel.DataAnnotations;

namespace SteamCopyCat.Data
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public int Calories { get; set; }
        public string Category { get; set; }

        [Range(1, int.MaxValue)]
        public double Price { get; set; }

        
        public string Image { get; set; }
    }
}
