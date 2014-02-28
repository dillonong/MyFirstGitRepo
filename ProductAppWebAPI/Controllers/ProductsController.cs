﻿using ProductAppWebAPI.Models;
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
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name="Tomato Soup", Category="Groceries", Price=1.23M },
            new Product {Id=2, Name="Yoyo", Category="Toys", Price=3.75M },
            new Product{Id=3, Name="Hammer", Category="Hardware", Price=12.03M}
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault(x=>x.Id == id);
            if (product == null)
                return NotFound();
            else
                return Ok(product);
        }
    }
}
