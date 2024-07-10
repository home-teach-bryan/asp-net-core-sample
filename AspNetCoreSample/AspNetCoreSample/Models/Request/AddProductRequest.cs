using System.ComponentModel.DataAnnotations;

namespace AspNetCoreSample.Models.Request;

public class AddProductRequest
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
    [MaxLength(length: 10, ErrorMessage = "Name cannot exceed 10 characters")]
    public string Name { get; set; }
    
    [Range(1, double.MaxValue, ErrorMessage = "Price must be great than 1")]
    public decimal Price { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be great than 1")]
    public int Quantity { get; set; }
}