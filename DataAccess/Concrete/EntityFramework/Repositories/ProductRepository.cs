using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Linq;

namespace DataAccess.Concrete.EntityFramework.Repositories;

public class ProductRepository : EfEntityRepositoryBase<Product, ProjectDbContext>, IProductRepository
{
    public ProductRepository(ProjectDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetProductsByPagingAsync(string order, int skip, int take,
        Expression<Func<Product, bool>> expression = null)
    {
        List<Product> products = new();


        if (expression is null)
        {
            products = await Context.Products.OrderByDescending(x => x.Id).ToListAsync();
        }

        throw new System.NotImplementedException();
    }
}