using AnahoneAPI.Models;
using Microsoft.EntityFrameworkCore;
using WebApplicationAnaHon.Data.Models;

namespace WebApplicationAnaHon.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }
        public DbSet<MissingPersons> Persons { get; set; }
        public DbSet<BloodDonor> Donors { get; set; }
    }

}
