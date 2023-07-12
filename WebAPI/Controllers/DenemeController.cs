using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Handlers.Profiles;
using Business.Handlers.Profiles.Commands;
using Microsoft.AspNetCore.Http;
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
    }
}