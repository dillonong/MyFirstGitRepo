using ProductAppWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductAppWebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        //Using a Repository now instead
        //Product[] products = new Product[]
        //{
        //    new Product { Id = 1, Name="Tomato Soup", Category="Groceries", Price=1.23M },
        //    new Product {Id=2, Name="Yoyo", Category="Toys", Price=3.75M },
        //    new Product{Id=3, Name="Hammer", Category="Hardware", Price=12.03M}
        //};
        static readonly IProductRepository repository = new ProductRepository();

        public IEnumerable<Product> GetAllProducts()
        {
            //return products;
            //Now using the repository
            return repository.GetAll();
        }

        //The following is replaced with using the repository
        //public IHttpActionResult GetProduct(int id)
        //{
        //    var product = products.FirstOrDefault(x=>x.Id == id);
        //    if (product == null)
        //        return NotFound();
        //    else
        //        return Ok(product);
        //}

        public Product GetProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return item;
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return repository.GetAll().Where(x => String.Equals(x.Category, category, StringComparison.OrdinalIgnoreCase));
        }

        //ADD 
        public HttpResponseMessage PostProduct(Product item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        //UPDATE
        public void PutProduct(int id, Product product)
        {
            product.Id = id;
            if (!repository.Update(product))
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        //DELETE
        public void DeleteProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            repository.Remove(id);
        }
    }
}
