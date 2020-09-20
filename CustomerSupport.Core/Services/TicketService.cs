using System;
using System.Linq;
using System.Collections.Generic;

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
        public void Create(CreateTicketDto ticketDto)
        {
            ITicket ticket = new BusinessLogic.Ticket(ticketDto);
            ticket.Create();
        }

        public void Delete(long id)
        {
            BusinessLogic.Ticket.Delete(id);
        }


        public bool Exists(long id)
        {
            using(var db = new CustomerSupportContext())
            {
                return db.Tickets.Any(t => t.Id == id);
            } 
        }


        public GetTicketDto Get(long id)
        {
            using(var db = new CustomerSupportContext())
            {
                return db.Tickets.Select(t => new GetTicketDto
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
        }

        public List<GetTicketDto> GetAll()
        {
            using(var db = new CustomerSupportContext())
            {
                return db.Tickets.Select(t => new GetTicketDto
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
        }

        public void Update(UpdateTicketDto ticketDto)
        {
            ITicket ticket = new BusinessLogic.Ticket(ticketDto);
            ticket.Upate();
        }
    }
}