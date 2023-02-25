using AuditingFields.Models;
using Microsoft.EntityFrameworkCore;

namespace AuditingFields.Persistence
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
    }
}
