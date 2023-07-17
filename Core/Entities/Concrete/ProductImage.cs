using System;

namespace Core.Entities.Concrete;

public class ProductImage : BaseEntity
{
    public int ProductId { get; set; }

    public string Name { get; set; }
    public string Url { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }


    public Product Product { get; set; }
}