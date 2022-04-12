using System;
using MediatR;
using ProductMicroservice.Models;
using System.Threading.Tasks;
namespace ProductApi.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public Guid Id { get; set; }
    }
}
