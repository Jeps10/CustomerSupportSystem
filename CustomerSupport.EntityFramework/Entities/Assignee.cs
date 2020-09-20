using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSupport.EntityFramework.Entities
{
    [Table("Assignees")]
    public class Assignee
    {
        public long Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [NotMapped]
        public string Fullname { get { return $"{Firstname} {Lastname}"; } }
    }
}