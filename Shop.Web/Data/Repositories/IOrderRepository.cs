
namespace Shop.Web.Data.Repositories
{
    using Shop.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    internal interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IQueryable<Order>> GetOrdersAsync(string userName);

    }
}
