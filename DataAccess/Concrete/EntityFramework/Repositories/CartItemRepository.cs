using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework.Repositories;

public class CartItemRepository : EfEntityRepositoryBase<CartItem, ProjectDbContext>, ICartItemRepository
{
    public CartItemRepository(ProjectDbContext context) : base(context)
    {
    }
}