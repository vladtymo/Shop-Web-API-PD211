using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        //[Required]
        public string Title { get; set; }
        //[Url(ErrorMessage = "URL Address must be valid.")]
        public string? ImageUrl { get; set; }
        //[Range(0, int.MaxValue)]
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        //[MaxLength(100)]
        public string? Description { get; set; }
        public int CategoryId { get; set; }

        // ----- navigation properties
        public Category? Category { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}