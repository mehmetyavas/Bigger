using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework.Repositories;

public class CartRepository : EfEntityRepositoryBase<Cart, ProjectDbContext>, ICartRepository
{
    public CartRepository(ProjectDbContext context) : base(context)
    {
    }
}