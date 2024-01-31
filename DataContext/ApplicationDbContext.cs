using Microsoft.EntityFrameworkCore;
using WebAPIAssessment.Model;

namespace WebAPIAssessment.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

      
        public DbSet<Model.Task> Tasks { get; set; }
    }
}
