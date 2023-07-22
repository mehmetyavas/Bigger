using System;

namespace Core.Entities.Concrete;

public class Cart : BaseEntity
{
    public decimal TotalPrice { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public virtual User User { get; set; }
}