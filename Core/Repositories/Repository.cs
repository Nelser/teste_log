using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using teste_log.Core.Infra.Repositories;
using teste_log.DTOs;

namespace teste_log.Core.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _context;
        private DbSet<TEntity> _dbset;
        private DbConnection con => _context.Database.GetDbConnection(); 

        public Repository(DbContext context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }

        public async Task<EventLogDTO> AddAsync(EventLogDTO dto)
        {
            var sql = $@"INSERT INTO EventLog (Category, EventId, LogLevel, Message, CreatedTime)
                        VALUES(@Category, @EventId, @LogLevel, @Message, @CreatedTime)";
            var query = await Task.Run(() => con.Query<EventLogDTO>(sql, new {Category = dto.Category, 
                                                                              EventId = dto.EventId, 
                                                                              LogLevel = dto.LogLevel, 
                                                                              Message = dto.Message, 
                                                                              CreatedTime = dto.CreatedTime}));
            return query;
        }

        public async Task<IEnumerable<EventLogDTO>> ListAllAsync()
        {
            var sql = $@"SELECT 
                            Category,
                            EventId,
                            LogLevel,
                            Message,
                            CreatedTime
                        FROM EventLog";
            var query = await Task.Run(() => con.Query<EventLogDTO>(sql)); 
            return query;
        }

        public async Task UpdateAsync(EventLogDTO dto)
        {
            var sql = $@"UPDATE EventLog SET @Category = {dto.Category}, @EventId = EventId, @LogLevel = LogLevel, @Message = Message, @CreatedTime = {dto.CreatedTime}";
            var query = await Task.Run(() => con.Query<EventLogDTO>(sql) new { Category = dto.Category,
                                                                               EventId = dto.EventId, 
                                                                               Message = dto.Message, 
                                                                               LogLevel = dto.LogLevel, 
                                                                               CreatedTime = dto.Message}); 
        }

        public Task GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}