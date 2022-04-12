using System;
using System.Threading.Tasks;
using ProductMicroservice.Repository;
using ProductMicroservice.Models;
using System.Threading;
using MediatR;
using System.Collections.Generic;

namespace ProductMicroservice.CQRS.Queries
{

    public class GetProductListQueryHandler : IRequestHandler<GetProductLisQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductListQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductLisQuery request, CancellationToken cancellationToken)
        {
            
            return  await Task.FromResult( _productRepository.GetProducts());


        }

    }
}

