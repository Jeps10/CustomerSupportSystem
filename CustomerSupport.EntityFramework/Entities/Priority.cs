using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSupport.EntityFramework.Entities
{
    [Table("Priorities")]
    public class Priority
    {
        public long Id { get; set; }

        public string Description { get; set; }
    }
}