using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ōhara.Doppler.Domain.Models;

namespace Ōhara.Doppler.Persistence.Context
{
    public class DopplerDbContext: IdentityDbContext<User, Role, long>
    {
        public DopplerDbContext(DbContextOptions<DopplerDbContext> options)
            : base(options)
        {
        }

        public DopplerDbContext()
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
        /// <summary>
        /// Get Connection String From SharedSettings
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            return string.Empty;
        }
    }
}