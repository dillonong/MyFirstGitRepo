using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


///<Summary>
///We need to store a collection of products. It’s a good idea to separate the collection from our service 
///implementation. That way, we can change the backing store without rewriting the service class. 
///This type of design is called the repository pattern. Start by defining a generic interface for the repository
///
namespace ProductAppWebAPI.Models
{
    interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        Product Add(Product item);
        void Remove(int id);
        bool Update(Product item);
    }
}
