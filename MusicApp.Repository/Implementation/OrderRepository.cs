using Microsoft.EntityFrameworkCore;
using MusicApp.Domain;
using MusicApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;

        public OrderRepository(ApplicationDbContext context)
        { 
            this.context = context;
            entities = context.Set<Order>();
        }

        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Order GetDetailsForOrder(BaseEntity id)
        {
            throw new NotImplementedException();
        }
        // TODO
        //public List<Order> GetAllOrders()
        //{
        //    return entities
        //      .Include(z => z.ProductsInOrder)
        //      .Include(z => z.Owner)
        //      .Include("ProductsInOrder.Product")
        //      .ToList();
        //}

        //public Order GetDetailsForOrder(BaseEntity id)
        //{
        //    return entities
        //       .Include(z => z.ProductsInOrder)
        //       .Include(z => z.Owner)
        //       .Include("ProductsInOrder.Product")
        //       .SingleOrDefaultAsync(z => z.Id == id.Id).Result;
        //}
    }
}
