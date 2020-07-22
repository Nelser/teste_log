using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using teste_log.Core.Infra.Repositories;
using teste_log.Interfaces.Repositories;
using teste_log.models;

namespace teste_log.Repositories
{
    public class EventLogRepository : IEventLogRepository
    {
        private IRepository<EventLog> _repository;

        public EventLogRepository(IRepository<EventLog> repository)
        {
            _repository = repository;
        }
        public async Task<EventLog> AdicionarEventLog(EventLog eventLog)
        {
            await _repository.AddAsync(eventLog);
            return eventLog;
        }

        public async Task EditarEventLog(EventLog eventLog)
        {
            await _repository.UpdateAsync(eventLog);
        }

        public Task<EventLog> ObterEventPorId(int id)
        {
            return await _repository.GetByIdAsync
        }

        public async Task<IReadOnlyList<EventLog>> GetEventLogs()
        {
            var list = await _repository.ListAllAsync();
            return list.ToList(); 
        }
    }
}