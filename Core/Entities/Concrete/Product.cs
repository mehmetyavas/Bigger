using System;

namespace Core.Entities.Concrete;

public class Product : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public string BaseImageUrl { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ProductImage Image { get; set; }
}