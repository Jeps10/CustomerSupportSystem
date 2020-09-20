using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using CustomerSupport.EntityFramework.Entities;
using CustomerSupport.Core.Models;
using CustomerSupport.Core.BusinessLogic;

namespace CustomerSupport.Core.Services
{
    public interface ITicketService
    {
        List<GetTicketDto> GetAll();

        GetTicketDto Get(long id);

        bool Exists(long id);

        void Delete(long id);

        void Update(UpdateTicketDto ticket);

        void Create(CreateTicketDto ticket);
    }

    public class TicketService : ITicketService
    {
        private readonly CustomerSupportContext _db;
        
        public TicketService(CustomerSupportContext db) => _db = db;

        public void Create(CreateTicketDto ticketDto)
        {
            ITicket ticket = new BusinessLogic.Ticket(ticketDto, _db);
            ticket.Create();
        }

        public void Delete(long id)
        {
            var ticket = _db.Tickets.FirstOrDefaultAsync(t => t.Id == id).Result;
            
            if(ticket is null)
                throw new Exception("Ticket does not exist.");

            _db.Tickets.Remove(ticket);
            _db.SaveChanges();
        }


        public bool Exists(long id)
        {
            return _db.Tickets.Any(t => t.Id == id);
        }


        public GetTicketDto Get(long id)
        {
            return _db.Tickets.Select(t => new GetTicketDto
            {
                Id = t.Id,
                ProjectId = t.ProjectId,
                Project = t.Project.Description,
                AssigneeId = t.AssigneeId,
                Assignee = t.Assignee.Fullname,
                IssueId = t.IssueId,
                Issue = t.Issue.Description,
                PriorityId = t.PriorityId,
                Priority = t.Priority.Description,
                Reporter = t.Reporter,
                DueDate = t.DueDate.ToShortDateString(),
                Description = t.Description,
                Summary = t.Summary,
                OriginalEstimate = t.OriginalEstimate
            }).FirstOrDefault(t => t.Id == id);
        }

        public List<GetTicketDto> GetAll()
        {
            return _db.Tickets.Select(t => new GetTicketDto
            {
                Id = t.Id,
                ProjectId = t.ProjectId,
                Project = t.Project.Description,
                AssigneeId = t.AssigneeId,
                Assignee = t.Assignee.Fullname,
                IssueId = t.IssueId,
                Issue = t.Issue.Description,
                PriorityId = t.PriorityId,
                Priority = t.Priority.Description,
                Reporter = t.Reporter,
                DueDate = t.DueDate.ToShortDateString(),
                Description = t.Description,
                Summary = t.Summary,
                OriginalEstimate = t.OriginalEstimate
            }).ToList();
        }

        public void Update(UpdateTicketDto ticketDto)
        {
            ITicket ticket = new BusinessLogic.Ticket(ticketDto, _db);
            ticket.Upate();
        }
    }
}