using Exam.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.API
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext>options):base(options)
        {
                
        }
        public DbSet<User> Users { get; set; }
    }
}
