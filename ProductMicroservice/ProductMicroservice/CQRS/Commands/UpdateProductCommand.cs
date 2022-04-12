using MediatR;
using ProductMicroservice.Models;

namespace ProductMicroservice.CQRS.Commands
{

    public class UpdateProductCommand : IRequest<Product>
    {
        public Product product { get; set; }
    }
}
