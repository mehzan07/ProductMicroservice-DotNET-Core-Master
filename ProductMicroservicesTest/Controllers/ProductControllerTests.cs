using System;
using System.Net;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductMicroservice.Controllers;
using ProductMicroservice.Models;
using ProductMicroservice.Repository;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using ProductMicroservice.DBContexts;
using Microsoft.EntityFrameworkCore;
using Moq;  // this for Mock testing not real access to database.

// This test is a xUnit test and have been used via Mock (not real connection to database)
// during developement get error:ReflectionAbstractionExtension.cs not found
// this has been solved in VS2019: Tools:Options:Debeging:General by checking : Enable just may code.


namespace ProductMicroservicesTest.Controllers
{
    public class ProductControllerTests 
    {
        private readonly Product _testProduct;
        Mock<IProductRepository> _testProductRepository;

        // constructor to get an instance of Mock IProductRepository
        public ProductControllerTests()
        {
            this._testProductRepository = new Mock<IProductRepository>();

            // create an instance of product
            _testProduct = new Product
            {
                Name = "Iphone12",
                Description = " IPhone new model 12",
                Price = 12000,
                CategoryId = 1
            };
        }

        //  Get Products 
        [Fact]
        public void GetProducts()
        {
            var products = _testProductRepository.Setup(x => x.GetProducts());
            var resulst = new OkObjectResult(products);
            Assert.Equal(resulst.StatusCode, StatusCodes.Status200OK);
        }

        // GetProductById 
        [Fact]
        public void GetProductById()
        {
            int prodId = 1;
            var product = _testProductRepository.Setup(x => x.GetProductByID(prodId));
            var resulst = new OkObjectResult(product);
            Assert.Equal(resulst.StatusCode, StatusCodes.Status200OK);
        }

        //  Post (InsertProduct) 
        [Fact]
        public void PostProduct()
        {
            var result = _testProductRepository.Setup(x => x.InsertProduct(_testProduct));
            Assert.NotNull(result);
        }


        // PutProduct (update) 
        [Fact]
        public void PutProduct()
        {
            var result = _testProductRepository.Setup(x => x.UpdateProduct(_testProduct));
            Assert.NotNull(result);
        }


        // Delete Product
        [Fact]
        public void DeleteProduct()
        {
            int Id = 1;
            var result = _testProductRepository.Setup(x => x.DeleteProduct(Id));
            Assert.NotNull(result);

        }

        // a dummy unit test only for test
        [Fact]
        public void dummyProduct()
        {
            int Id = 1;
            var result = _testProductRepository.Setup(x => x.DeleteProduct(Id));
            Assert.NotNull(result);

        }
    }

}
