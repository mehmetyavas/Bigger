using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework.Repositories;

public class ProductRepository : EfEntityRepositoryBase<Product, ProjectDbContext>, IProductRepository
{
    public ProductRepository(ProjectDbContext context) : base(context)
    {
    }
}