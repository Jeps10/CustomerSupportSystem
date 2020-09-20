using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSupport.EntityFramework.Entities
{
    [Table("Issues")]
    public class Issue
    {
        public long Id { get; set; }

        public string Description { get; set; }
    }
}