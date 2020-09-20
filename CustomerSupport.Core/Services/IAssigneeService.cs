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
        public async Task<List<BaseEntityDto>> GetAll()
        {
            using(var db = new CustomerSupportContext())
            {
                return await db.Assignees.Select(p => new BaseEntityDto
                {
                    Id = p.Id,
                    Description = p.Fullname
                }).ToListAsync();
            }
        }
    }
}