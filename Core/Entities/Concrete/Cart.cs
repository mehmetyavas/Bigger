using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Entities.Concrete;

public class Cart : BaseEntity
{
    public decimal TotalPrice { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<CartItem> CartItem { get; set; }
}