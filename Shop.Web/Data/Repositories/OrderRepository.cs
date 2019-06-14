﻿
namespace Shop.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Shop.Web.Data.Entities;
    using Shop.Web.Helpers;
    using System.Linq;
    using System.Threading.Tasks;

    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;

        public OrderRepository(DataContext context, IUserHelper userHelper) : base(context)
        {
            this.context = context;
            this.userHelper = userHelper;
        }

        public async Task<IQueryable<Order>> GetOrdersAsync(string userName)
        {
            var user = await userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return null;
            }

            if (await userHelper.IsUserInRoleAsync(user, "Admin"))
            {
                return context.Orders
                    .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                    .OrderByDescending(o => o.OrderDate);
            }

            return context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Where(o => o.User == user)
                .OrderByDescending(o => o.OrderDate);

        }
    }
}
