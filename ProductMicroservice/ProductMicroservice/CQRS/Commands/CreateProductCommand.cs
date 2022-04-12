using MediatR;
using ProductMicroservice.Models;

namespace ProductMicroservice.CQRS.Commands
{
    
    public class CreateProductCommand : IRequest<Product>
    {
        public Product product { get; set; }
    }
}
