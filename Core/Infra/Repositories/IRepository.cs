using System.Collections.Generic;
using System.Threading.Tasks;
using teste_log.DTOs;

namespace teste_log.Core.Infra.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<EventLogDTO>> ListAllAsync();
        Task<EventLogDTO> AddAsync(EventLogDTO dto);
        Task UpdateAsync(EventLogDTO dto);
        Task GetByIdAsync(int id);
    }
}