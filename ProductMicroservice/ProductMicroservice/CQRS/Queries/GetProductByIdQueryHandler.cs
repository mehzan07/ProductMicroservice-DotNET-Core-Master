using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ProductMicroservice.Repository;
using ProductMicroservice.Models;


namespace ProductMicroservice.CQRS.Queries
{

    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public  async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            
            return await Task.FromResult(_productRepository.GetProductByID(request.Id));
            
        }
        
    }

}
