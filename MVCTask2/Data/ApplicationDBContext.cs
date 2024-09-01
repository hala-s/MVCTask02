using Microsoft.EntityFrameworkCore;
using MVCTask2.Models;

namespace MVCTask2.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
