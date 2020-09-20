using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSupport.EntityFramework.Entities
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        public long Id { get; set; }
        
        [ForeignKey("Project")]
        public long ProjectId { get; set; }

        public Project Project { get; set; }

        [ForeignKey("Issue")]
        public long IssueId { get; set; }

        public Issue Issue { get; set; }

        [ForeignKey("Assignee")]
        public long AssigneeId { get; set; }

        public Assignee Assignee { get; set; }

        [ForeignKey("Priority")]
        public long PriorityId { get; set; }
        
        public Priority Priority { get; set; }

        public string Type { get; set; }

        public string Summary { get; set; }

        public string Reporter { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public string OriginalEstimate { get; set; }
    }
}