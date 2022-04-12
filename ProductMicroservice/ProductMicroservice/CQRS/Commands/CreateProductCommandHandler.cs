using MediatR;
using ProductMicroservice.Models;
using ProductMicroservice.Repository;
using System.Threading;
using System.Threading.Tasks;
namespace ProductMicroservice.CQRS.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _ProductRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }
        
        
        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
          return await Task.FromResult(_ProductRepository.InsertProduct(request.product));
        }
    }
}
