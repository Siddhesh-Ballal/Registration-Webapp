using Microsoft.EntityFrameworkCore;
using RegistrationTask.Models;

namespace RegistrationTask.Data
{
    public class UserDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public UserDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }



        public DbSet<User> UsersRegistration { get; set; }
    }
}
