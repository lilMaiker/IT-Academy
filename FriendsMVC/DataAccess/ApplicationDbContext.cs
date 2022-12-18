using FriendsMVC.DataAccess.Models;

using Microsoft.EntityFrameworkCore;

namespace FriendsMVC.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Friend> Friends { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
