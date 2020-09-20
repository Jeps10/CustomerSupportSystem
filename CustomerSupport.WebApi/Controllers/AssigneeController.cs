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
    [Route("api/assignees")]
    public class AssigneeController : ControllerBase
    {
        private readonly IAssigneeService _assigneeService;

        public AssigneeController(IAssigneeService assigneeService)
        {
           _assigneeService = assigneeService;
        }

        public async Task<IActionResult> GetAll() => Ok(await _assigneeService.GetAll());
    }
}