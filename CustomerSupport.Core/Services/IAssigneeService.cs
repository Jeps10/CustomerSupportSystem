using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using CustomerSupport.Core.Models;
using CustomerSupport.EntityFramework.Entities;

namespace CustomerSupport.Core.Services
{

    public interface IAssigneeService: IEntityService { }

    public class AssigneeService : IAssigneeService
    {
        private readonly CustomerSupportContext _db;

        public AssigneeService(CustomerSupportContext db) => _db = db;

        public async Task<List<BaseEntityDto>> GetAll()
        {
            return await _db.Assignees.Select(p => new BaseEntityDto
            {
                Id = p.Id,
                Description = p.Fullname
            }).ToListAsync();
        }
    }
}