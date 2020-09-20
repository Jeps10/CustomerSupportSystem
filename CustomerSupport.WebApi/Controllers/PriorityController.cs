using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CustomerSupport.Core.Services;
using CustomerSupport.Core.Models;

namespace CustomerSupport.WebApi.Controllers
{
    [ApiController]
    [Route("api/priorities")]
    public class PriorityController : ControllerBase
    {
        private readonly IPriorityService _priorityService;

        public PriorityController(IPriorityService priorityService)
        {
           _priorityService = priorityService;
        }

        public async Task<IActionResult> GetAll() => Ok(await _priorityService.GetAll());
    }
}