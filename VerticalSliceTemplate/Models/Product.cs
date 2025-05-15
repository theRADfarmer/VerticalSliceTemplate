using System.ComponentModel.DataAnnotations;

namespace VerticalSliceTemplate.Models
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "Name length cannot exceed 30 characters.")]
        public string Name { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; set; }
    }
}
