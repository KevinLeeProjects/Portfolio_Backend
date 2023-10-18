using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio_Backend.Models
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { }

        public DbSet<LoginModel> login { get; set; }
        public DbSet<ProjectModel> projects { get; set; }
    }
}
