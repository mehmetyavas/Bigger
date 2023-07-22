using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Repositories;

public class AddressRepository : EfEntityRepositoryBase<Address, ProjectDbContext>, IAddressRepository
{
    public AddressRepository(ProjectDbContext context) : base(context)
    {
    }
}