using ECommerce.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("AddProductWithMediator")]
        public async Task<IActionResult> AddProduct(AddProductCommand product)
        {
            var result = await _mediator.Send(product);
            if (result.Status)
                return Ok(result);

           
            return BadRequest(result);
        }


        [HttpGet("GetProductsWithMediator")]
        public async Task<IActionResult> GetProducts()
        {
            var query = new GetAllProductsQuery();
            var result = await _mediator.Send(query);
            if (result.Status)
                return Ok(result);


            return BadRequest(result);
        }
    }
}
