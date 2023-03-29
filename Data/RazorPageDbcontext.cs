using ASPNET_QL.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_QL.Data
{
    public class RazorPageDbcontext : DbContext
    {
        public RazorPageDbcontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
