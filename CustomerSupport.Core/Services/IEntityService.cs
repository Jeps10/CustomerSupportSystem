using System.Threading.Tasks;
using System.Collections.Generic;
using CustomerSupport.Core.Models;

namespace CustomerSupport.Core.Services
{
    public interface IEntityService
    {
        Task<List<BaseEntityDto>> GetAll();
    }
}