using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Models;
using ProductMicroservice.Repository;
using System.Threading;
using System.Threading.Tasks;
using ProductMicroservice.RabbitMQMessaging.Sendmesage;

namespace ProductMicroservice.CQRS.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductUpdateSender _productUpdateSender;

        public UpdateProductCommandHandler(IProductRepository productRepository, IProductUpdateSender productUpdateSender)
        {
            _productRepository = productRepository;
            _productUpdateSender = productUpdateSender;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
        var _product=  await Task.FromResult(_productRepository.UpdateProduct(request.product));
          _productUpdateSender.SendProduct(_product);
            return _product;
        }
    }
}

