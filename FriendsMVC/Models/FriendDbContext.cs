using Microsoft.EntityFrameworkCore;

namespace FriendsMVC.Models
{
    public class FriendDbContext : DbContext
    {
        public FriendDbContext(DbContextOptions<FriendDbContext> options) : base(options) { }

        public DbSet<Friend> Friends { get; set; }
    }
}
