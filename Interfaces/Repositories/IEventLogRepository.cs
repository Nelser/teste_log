using System.Collections.Generic;
using System.Threading.Tasks;
using teste_log.models;

namespace teste_log.Interfaces.Repositories
{
    public interface IEventLogRepository
    {
        Task<EventLog> AdicionarEventLog(EventLog eventLog);
        Task EditarEventLog(EventLog eventLog);
        Task<IReadOnlyList<EventLog>> GetEventLogs();
        Task<EventLog> ObterEventPorId(int id);
    }
}