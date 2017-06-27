using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStore.Domain.Entities
{
   public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            CartLine line = lineCollection.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
            if (line.Quantity==1)
            {
                lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
            }
            else
            {
                line.Quantity--;
            }
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price*e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

    }

   public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}