using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract;

public interface ICartItemRepository : IEntityRepository<CartItem>
{
}