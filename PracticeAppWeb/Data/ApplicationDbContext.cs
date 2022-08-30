using Microsoft.EntityFrameworkCore;
using PracticeAppWeb.Models;

namespace PracticeAppWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        
    }
}
