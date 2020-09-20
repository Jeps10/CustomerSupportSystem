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
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
           _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _projectService.GetAll());
    }
}