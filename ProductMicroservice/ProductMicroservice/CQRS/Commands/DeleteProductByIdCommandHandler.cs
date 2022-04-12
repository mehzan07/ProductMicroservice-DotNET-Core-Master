using MediatR;
using ProductMicroservice.Models;
using ProductMicroservice.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace ProductMicroservice.CQRS.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductByIdCommand, Product>
    {
        private readonly IProductRepository _ProductRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }


        public async Task<Product> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_ProductRepository.DeleteProduct(request.Id));
        }
    }
}
