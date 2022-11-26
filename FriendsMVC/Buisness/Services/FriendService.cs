using FriendsMVC.Buisness.Contract.Interfaces;
using FriendsMVC.DataAccess;

using Microsoft.EntityFrameworkCore;

namespace FriendsMVC.Buisness.Services
{
    public class FriendService : IFriendService
    {
        private FriendDbContext _dbContext;
        public FriendService(FriendDbContext context)
        {
            _dbContext = context;
        }

        public Task<List<DataAccess.Models.Friend>> GetFriends()
        {
            return _dbContext.Friends.ToListAsync();
        }
    }
}
