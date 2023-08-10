using System.ComponentModel.DataAnnotations;

namespace SimpleUserAuth.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
