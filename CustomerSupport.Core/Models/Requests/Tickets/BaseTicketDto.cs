using System;
using System.Linq;
using System.Collections.Generic;
using CustomerSupport.EntityFramework.Entities;

namespace CustomerSupport.Core.Models
{
    public class BaseTicketDto
    {
        public long ProjectId { get; set; }

        public string Project { get; set; }

        public long IssueId { get; set; }

        public string Issue { get; set; }

        public long AssigneeId { get; set; }

        public string Assignee { get; set; }

        public string Type { get; set; }

        public string Summary { get; set; }

        public string Reporter { get; set; }

        public string DueDate { get; set; }

        public string Description { get; set; }

        public long PriorityId { get; set; }

        public string Priority { get; set; }

        public string OriginalEstimate { get; set; }

        public virtual Dictionary<string, string> GetValidationErrors(CustomerSupportContext db)
        {
            var errors = new Dictionary<string, string>();
            if(ProjectId == 0)
                errors.Add("ProjectId", "Please select a project.");
            else {
                if(!db.Projects.Any(p => p.Id == ProjectId))
                    errors.Add("ProjectId", "Invalid project id");
            }

            if(IssueId == 0)
                errors.Add("IssueId", "Please select a type.");
            else {
                if(!db.Issues.Any(i => i.Id == IssueId))
                    errors.Add("IssueId", "Invalid type id.");
            }

            if(PriorityId == 0)
                errors.Add("PriorityId", "Please select a priority.");
            else {
                if(!db.Priorities.Any(p => p.Id == PriorityId))
                    errors.Add("PriorityId", "Invalid priority id.");
            }

            if(AssigneeId == 0)
                errors.Add("AssigneeId", "Please select an assignee.");
            else {
                if(!db.Assignees.Any(a => a.Id == AssigneeId))
                    errors.Add("AssigneeId", "Invalid assignee id.");
            }

            if(string.IsNullOrWhiteSpace(Description))
                errors.Add("Description", "Please enter the ticket description.");
                
            if(string.IsNullOrWhiteSpace(Summary))
                errors.Add("Summary", "Please enter the ticket summary.");

            if(string.IsNullOrWhiteSpace(Reporter))
                errors.Add("Reporter", "Please enter the ticket reporter.");

            if(string.IsNullOrWhiteSpace(OriginalEstimate))
                errors.Add("OriginalEstimate", "Please select an estimate.");

            if(string.IsNullOrWhiteSpace(DueDate))
                errors.Add("DueDate", "Please enter a due date.");
            else {
                DateTime dt;
                if(!DateTime.TryParse(DueDate, out dt)) {
                    errors.Add("DueDate", "Please enter a valid due date.");
                }
            }
            return errors;
        }
    }
}