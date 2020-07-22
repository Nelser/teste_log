using Microsoft.AspNetCore.Mvc;
using teste_log.models;
using Dapper;
using teste_log.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Serilog;
using teste_log.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace teste_log.Controllers
{
    [ApiController]
    [Route("api/")]
    public class EventLogController : ControllerBase
    {
        // private readonly ILogger _logger;
        private readonly Context _context;
        private IEventLogRepository _repository;
        public DbConnection con => _context.Database.GetDbConnection(); 
        //private string SqlString = "Server=localhost;User Id=root;Password=mz0079tuk6;Database=teste_log;TreatTinyAsBoolean=false";

        public EventLogController(IEventLogRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public Task<IReadOnlyList<EventLog>> GetEvents()
        {
            return Task.Run(() => _repository.GetEventLogs());
        }

        // [HttpGet("EventById")]
        // public IActionResult GetEventById([FromRoute]int id)
        // {
        //     return Task.Run(() => _repository.GetEventLogs());
        // }

        [HttpPost("Create")]
        public IActionResult CreateEvents([FromBody]EventLogDTO dto)
        {
           return Task.Run(() => _repository.AdicionarEventLog());
        }

        
    }
}