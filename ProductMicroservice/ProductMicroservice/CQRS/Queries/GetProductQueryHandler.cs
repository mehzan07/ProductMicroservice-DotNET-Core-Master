using System;
using System.Threading.Tasks;
using ProductMicroservice.Repository;
using ProductMicroservice.Models;
using System.Threading;
using MediatR;
using System.Collections.Generic;

namespace ProductMicroservice.CQRS.Queries
{

    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductListQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {

            return await Task.FromResult<List<Product>>(request.Id == 0 ? _productRepository.GetProducts() : new List<Product>()
            {
                _productRepository.GetProductByID(request.Id)
            });


        }

    }
}

