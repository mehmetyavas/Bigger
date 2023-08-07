using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Handlers.Addresses.Commands;
using Business.Handlers.Addresses.Queries;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Controllers.User
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : BaseApiController
    {
        /// <summary>
        ///  User address
        /// </summary>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Address))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResult))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress(int id)
        {
            var record = await Mediator.Send(new GetAddressQuery(id));

            return GetResponseOnlyResultData(record);
        }

        /// <summary>
        ///   List User address
        /// </summary>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Address>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResult))]
        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var record = await Mediator.Send(new GetAddressesQuery());

            return GetResponseOnlyResultData(record);
        }

        /// <summary>
        ///   Create User Address
        /// </summary>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResult))]
        [HttpPost]
        public async Task<IActionResult> PostAddress(CreateAddressCommand req)
        {
            var record = await Mediator.Send(req);

            return GetResponseOnlyResult(record);
        }

        /// <summary>
        ///   Update User Address
        /// </summary>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResult))]
        [HttpPost("update")]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand req)
        {
            var record = await Mediator.Send(req);

            return GetResponseOnlyResult(record);
        }

        /// <summary>
        ///   Delete User Address
        /// </summary>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResult))]
        [HttpPost("delete/{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var record = await Mediator.Send(new DeleteAddressCommand(id));

            return GetResponseOnlyResult(record);
        }
    }
}