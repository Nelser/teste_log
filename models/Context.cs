using Microsoft.EntityFrameworkCore;


namespace teste_log.models
{
    public class Context : DbContext
    {
        public DbSet<EventLog> EventLog { get; set; }
        public Context(DbContextOptions options): base(options){}   
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EventLog>();
        }
    }
}