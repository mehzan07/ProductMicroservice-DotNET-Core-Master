using MediatR;
using ProductMicroservice.Models;
using ProductMicroservice.Repository;
using System.Threading;
using System.Threading.Tasks;
namespace ProductApi.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _ProductRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }

        //public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        //{
        //   return await _ProductRepository.AddAsync(request.Product);

        //}
        public Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
          return Task.FromResult(_ProductRepository.InsertProduct(request.Product));
        }
    }
}
