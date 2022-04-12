using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Models;
using ProductMicroservice.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace ProductMicroservice.CQRS.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductRepository _ProductRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            // var ok = await  Task.FromResult(_ProductRepository.UpdateProduct(request.product));
          return await Task.FromResult(_ProductRepository.UpdateProduct(request.product));
        }
    }
}

