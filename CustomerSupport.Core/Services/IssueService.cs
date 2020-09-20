using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using CustomerSupport.Core.Models;
using CustomerSupport.EntityFramework.Entities;

namespace CustomerSupport.Core.Services
{
    public interface IIssueService: IEntityService { }

    public class IssueService : IIssueService
    {
        public async Task<List<BaseEntityDto>> GetAll()
        {
            using(var db = new CustomerSupportContext())
            {
                return await db.Issues.Select(p => new BaseEntityDto
                {
                    Id = p.Id,
                    Description = p.Description
                }).ToListAsync();
            }
        }
    }
}