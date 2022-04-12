using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ProductMicroservice.Repository;
using ProductMicroservice.Models;

namespace ProductApi.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public  Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            int pId = new int();
            return Task.FromResult(_productRepository.GetProductByID(pId));
            
        }
        
    }
}
