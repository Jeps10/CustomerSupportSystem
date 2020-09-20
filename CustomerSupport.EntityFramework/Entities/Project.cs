using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSupport.EntityFramework.Entities
{
    [Table("Projects")]
    public class Project
    {
        public long Id { get; set; }

        public string Description { get; set; }
    }
}