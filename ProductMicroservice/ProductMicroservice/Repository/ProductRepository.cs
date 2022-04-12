using Microsoft.EntityFrameworkCore;
using ProductMicroservice.DBContexts;
using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductMicroservice.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;

        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Product DeleteProduct(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            var prod = product;
            _dbContext.Products.Remove(product);
            Save();
            return prod;
        }

        public Product GetProductByID(int productId)
        {
            return _dbContext.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToList();

        }


        //public void InsertProduct(Product product)
        //{
        //    _dbContext.Add(product);
        //    Save();
        //}
        public Product InsertProduct(Product product)
        {
            _dbContext.Add(product);
            Save();
            return product;  // no return needed but because of method Handel in CreateProductCommandHandler in ProductApi we need this
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public Product UpdateProduct(Product product)
        {
           var retValue = _dbContext.Entry(product).State = EntityState.Modified;
            Save();
            return product;  // no return needed but because of method Handel in CreateProductCommandHandler in ProductApi we need this

        }
    }
}
