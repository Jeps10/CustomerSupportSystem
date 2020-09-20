using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using CustomerSupport.Core.Models;
using CustomerSupport.EntityFramework.Entities;

namespace CustomerSupport.Core.Services
{
    public interface IProjectService: IEntityService { }

    public class ProjectService : IProjectService
    {
        private readonly CustomerSupportContext _db;
        
        public ProjectService(CustomerSupportContext db) => _db = db;

        public async Task<List<BaseEntityDto>> GetAll()
        {
            return await _db.Projects.Select(p => new BaseEntityDto
            {
                Id = p.Id,
                Description = p.Description
            }).ToListAsync();
        }
    }
}