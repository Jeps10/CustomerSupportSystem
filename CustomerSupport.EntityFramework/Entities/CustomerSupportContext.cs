using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CustomerSupport.EntityFramework.Entities
{
    public class CustomerSupportContext: DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Issue> Issues { get; set; }

        public DbSet<Priority> Priorities { get; set; }

        public DbSet<Assignee> Assignees { get; set; }
        
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //     }
        // }



        public CustomerSupportContext(DbContextOptions<CustomerSupportContext> options)
            : base(options)
        { }
    }
}