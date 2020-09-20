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
        private readonly CustomerSupportContext _db;
        
        public IssueService(CustomerSupportContext db) => _db = db;

        public async Task<List<BaseEntityDto>> GetAll()
        {
            return await _db.Issues.Select(p => new BaseEntityDto
            {
                Id = p.Id,
                Description = p.Description
            }).ToListAsync();
        }
    }
}