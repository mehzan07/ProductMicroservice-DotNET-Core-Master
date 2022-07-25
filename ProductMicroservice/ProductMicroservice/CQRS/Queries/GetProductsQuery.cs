using System;
using System.Collections.Generic;
using MediatR;
using ProductMicroservice.Models;

namespace ProductMicroservice.CQRS.Queries
{
    public class GetProductListQuery : IRequest<List<Product>> 
    {
        public int Id { get; set; }
    }
}
