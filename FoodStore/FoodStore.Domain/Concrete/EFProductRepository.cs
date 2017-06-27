using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodStore.Domain.Abstract;
using FoodStore.Domain.Entities;

namespace FoodStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();


        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public IEnumerable<Product> P()
        {
            return context.Products;
        }
    }
}

