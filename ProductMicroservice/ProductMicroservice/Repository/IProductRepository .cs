using ProductMicroservice.Models;
using System.Collections.Generic;

namespace ProductMicroservice.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int productId);
       // void InsertProduct(Product product);
        Product InsertProduct(Product product);
        //void DeleteProduct(int productId);
        Product DeleteProduct(int productId);
        //void UpdateProduct(Product product);
        Product UpdateProduct(Product product);
        void Save();
    }
}

