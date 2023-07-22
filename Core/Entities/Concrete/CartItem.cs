using System;

namespace Core.Entities.Concrete;

public class CartItem : BaseEntity
{
    public int ProductId { get; set; }
    public int CartId { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    //relation
    public virtual Product Product { get; set; }
    public virtual Cart Cart { get; set; }
}