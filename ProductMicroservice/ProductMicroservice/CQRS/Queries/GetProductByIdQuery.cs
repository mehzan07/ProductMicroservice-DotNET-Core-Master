using System;
using MediatR;
using ProductMicroservice.Models;

namespace ProductMicroservice.CQRS.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }

}
