using MediatR;
using System.ComponentModel.DataAnnotations;

// CreateProduct.cs
// Defines the data and validation for creating a product. Used as a MediatR request.

namespace VerticalSliceTemplate.Pages.Products
{
    public class CreateProduct : IRequest
    {
        [MaxLength(30, ErrorMessage = "Name length cannot exceed 30 characters.")]
        public string Name { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; set; }
    }
}
