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
    [Route("api/issues")]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _issueService;

        public IssueController(IIssueService issueService)
        {
           _issueService = issueService;
        }

        public async Task<IActionResult> GetAll() => Ok(await _issueService.GetAll());
    }
}