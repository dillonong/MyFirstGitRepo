using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAppWebAPI.Models
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>();
        private int _nextId = 1;

        public ProductRepository()
        {
            Add(new Product { Name="Tomato Soup", Category="Groceries", Price=1.23M });
            Add(new Product { Name="Yoyo", Category="Toys", Price=3.75M });
            Add(new Product{ Name="Hammer", Category="Hardware", Price=12.03M});
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public Product Get(int id)
        {
            return products.Find(x => x.Id == id);
        }

        public Product Add(Product item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            item.Id = _nextId++;
            products.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            products.RemoveAll(x => x.Id == id);
        }

        public bool Update(Product item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            int index = products.FindIndex(x => x.Id == item.Id);
            if (index == -1)
                return false;
            products.RemoveAt(index);
            products.Add(item);
            return true;
        }
    }
}