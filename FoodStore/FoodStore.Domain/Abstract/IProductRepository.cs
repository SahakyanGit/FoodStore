using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodStore.Domain.Entities;

namespace FoodStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
