using FriendsMVC.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FriendsMVC.DataAccess
{
    public class FriendDbContext : DbContext
    {
        public FriendDbContext(DbContextOptions<FriendDbContext> options) : base(options) { }

        public DbSet<Friend> Friends { get; set; }
    }
}
