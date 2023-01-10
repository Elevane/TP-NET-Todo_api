using Todo.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Todo.Persistence.Entitites;

namespace Todo.Persistence
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(user =>
            {
                user.HasIndex(u => u.Id);
            });

            base.OnModelCreating(builder);
        }
    }
}