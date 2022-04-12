using System;
using System.Collections.Generic;
using MediatR;
using ProductMicroservice.Models;

namespace ProductMicroservice.CQRS.Queries
{
    public class GetProductLisQuery : IRequest<IEnumerable<Product>>  
    {
    }
}
