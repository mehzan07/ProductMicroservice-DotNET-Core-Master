using System;
using MediatR;
using ProductMicroservice.Models;

namespace ProductMicroservice.CQRS.Commands

{
    public class DeleteProductByIdCommand : IRequest<Product>
    {
        public int Id { get; set; }
    }

}
