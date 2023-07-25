using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract;

public interface IProductRepository : IEntityRepository<Product>
{
    public Task<IEnumerable<Product>> GetProductsByPagingAsync(string order, int skip, int take,
        Expression<Func<Product, bool>> expression = null);
}