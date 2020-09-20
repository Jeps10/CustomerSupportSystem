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
    [Route("api/tickets")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
           _ticketService = ticketService;
        }

        [HttpGet]
        public Task<IActionResult> GetAll()
        {
            return Task.FromResult<IActionResult>(Ok(_ticketService.GetAll()));
        }

        [HttpGet]
        [Route("{id}")]
        public Task<IActionResult> Get(long id)
        {
            return Task.FromResult<IActionResult>(Ok(_ticketService.Get(id)));
        }

        [HttpPost]
        public Task<IActionResult> Create(CreateTicketDto request)
        {
            var errors = request.GetValidationErrors();

            if(errors.Any()) {
                return Task.FromResult<IActionResult>(BadRequest(errors));
            }

            _ticketService.Create(request);
            return Task.FromResult<IActionResult>(Ok());
        }

        [HttpPut]
        public Task<IActionResult> Update(UpdateTicketDto request)
        {
            var errors = request.GetValidationErrors();

            if(errors.Any()) {
                return Task.FromResult<IActionResult>(BadRequest(errors));
            }

            _ticketService.Update(request);
            return Task.FromResult<IActionResult>(Ok());
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<IActionResult> Delete(long id)
        {
            if(!_ticketService.Exists(id))
                return Task.FromResult<IActionResult>(BadRequest(new Dictionary<string, string> { { "Id", "Ticket id does not exist." } }));

            _ticketService.Delete(id);
            return Task.FromResult<IActionResult>(Ok());
        }
    }
}
