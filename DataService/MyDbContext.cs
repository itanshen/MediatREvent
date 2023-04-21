using DataService.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataService
{
    public class MyDbContext : BaseDbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }

        public MyDbContext(DbContextOptions options, IMediator mediator) : base(options, mediator)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

    }
}