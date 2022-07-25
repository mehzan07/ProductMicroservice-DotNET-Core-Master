using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Models;
using ProductMicroservice.Repository;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using ProductMicroservice.CQRS.Commands;
using ProductMicroservice.CQRS.Queries;


/// <summary>
/// Product description
/// ProductMicroservice is based on .NET5 (.NET Core 5) With CRUD properties connected to SQL server DB
/// DataAccess: Repository DBContexts implemented with, Swagger, Dockerize (Docker, Container) CQRS, Mediator, RabbitMQ,
/// Methods: Get (Read), Post (Insert), Put (update) Delete, All Methods uses CQRS and mediator to distingish Read and Write 
/// Operations in the Database.
/// </summary>
namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        // new
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }



        /// <summary>
        ///     Action to retrieve all Products.
        /// </summary>
        /// <returns>Returns a list of all Products or an empty list, if no Product is exist</returns>
        /// <response code="200">Returned if the list of Products was retrieved</response>
        /// <response code="400">Returned if the Products could not be retrieved</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            try
            {
                var products = await _mediator.Send(new GetProductListQuery());
                return new OkObjectResult(products);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        ///     Action Get a Product.
        /// </summary>
        /// <param name="productId">The productId is a Prouct which should be retaind from DB </param>
        /// <returns>Returns is OK </returns>
        /// <response code="200">Returned if the Products has been found and retained </response>
        /// <response code="400">Returned if the Prodcut could not be found to retaind with ProductId</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{productId}", Name = "Get")]
        public async Task<ActionResult<Product>> Get(int productId)
        {
            try
            {

                var prod = await _mediator.Send(new GetProductByIdQuery
                {
                    Id = productId
                });
                if (prod == null)
                {
                    return BadRequest($"No Product found with the id {productId}");
                }
                else
                    return prod;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Action: Post to create a new product in the database.
        /// </summary>
        /// <param name="product">Model to create a new Product</param>
        /// <returns>Returns the created product</returns>
        /// <response code="200">Returned if the product was created</response>
        /// <response code="400">Returned if the model couldn't be parsed or the product couldn't be saved</response>
        /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            try
            {
                var prod = new CreateProductCommand
                {
                    product = _mapper.Map<Product>(product)
                };

                return await _mediator.Send(prod);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        ///  Action: Put to update a Product in the Database
        /// </summary>
        /// <param name="product">The product is a Prouct which should be updated in DB </param>
        /// <returns>Returns is OK </returns>
        /// <response code="200">Returned if the Product was updated </response>
        /// <response code="400">Returned if the Prodcut could not be found with Product.Id</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("Product")]
        public async Task<ActionResult> Put([FromBody] Product product)
        {
            try
            {
                var prod = new UpdateProductCommand
                {
                    product = _mapper.Map<Product>(product)
                };

                var ok = await _mediator.Send(prod);
                return new OkResult();

            }
            catch (Exception ex)
            {
                // return BadRequest(ex.Message);
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        ///   Action Delete: to delete a Product on the Database.
        /// </summary>
        /// <param name="productId">The productId is a Prouct which should be deleted from DB </param>
        /// <returns>Returns is OK </returns>
        /// <response code="200">Returned if the Product has been found and deleted </response>
        /// <response code="400">Returned if the Prodcut could not be found for  deletion with ProductId</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{productId}", Name = "Delete")]
        public async Task<IActionResult> Delete(int productId)
        {
            try
            {

                var prod = await _mediator.Send(new DeleteProductByIdCommand
                {
                    Id = productId
                });
                if (prod == null)
                {
                    return BadRequest($"No Product found with the id {productId}");
                }
                else
                    return new OkResult();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}