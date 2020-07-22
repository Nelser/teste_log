using System;

namespace teste_log.DTOs
{
    public class EventLogDTO
    {
        public string Category { get; set; }
        public int EventId { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}