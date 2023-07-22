using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework.Repositories;

public class ProductImageRepository : EfEntityRepositoryBase<ProductImage, ProjectDbContext>, IProductImageRepository
{
    public ProductImageRepository(ProjectDbContext context) : base(context)
    {
    }
}