using System.Threading.Tasks;
using Business.Enums;
using Business.Handlers.Products.Commands;
using Business.Handlers.Products.Queries;
using Business.Handlers.Profiles.Commands;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenemeController : BaseApiController
    {
        [HttpPost("update")]
        public async Task<IActionResult> UpdateUserProfile([FromForm] UpdateUserProfileCommand req)
        {
            return GetResponseOnlyResult(await Mediator.Send(req));
        }


        [HttpPost("productCreate")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductCommand req)
        {
            var result = await Mediator.Send(req);
            return GetResponseOnlyResult(result);
        }


        [HttpGet("getProduct")]
        public async Task<IActionResult> GetProduct(string q)
        {
            var result = await Mediator.Send(new GetProductQuery(q));
            var deneme = OrderEnum.priceASC;
            return GetResponseOnlyResult(result);
        }


        [HttpPost("productUpdate")]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductCommand req)
        {
            var result = await Mediator.Send(req);
            return GetResponseOnlyResult(result);
        }
    }
}