using FriendsMVC.DataAccess;

using Microsoft.EntityFrameworkCore;

namespace FriendsMVC
{
    public class StartUp
    {
        public static void MigrateDB(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();

                if (dbContext == null)
                {
                    throw new SystemException("This should never happen, the DbContext couldn't recolve!");
                }

                dbContext.Database.Migrate();
            }
        }
    }
}
