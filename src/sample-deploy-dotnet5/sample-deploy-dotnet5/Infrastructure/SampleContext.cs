using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options)
            : base(options)
        {

        }
        public DbSet<HogeFuga> HogeFugas { get; set; }
    }

}
