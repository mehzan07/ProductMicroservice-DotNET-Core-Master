using MediatR;
using ProductMicroservice.Models;
namespace ProductApi.Commands
{
    
    public class CreateProductCommand : IRequest<Product>
    {
        public Product Product { get; set; }
    }
}
