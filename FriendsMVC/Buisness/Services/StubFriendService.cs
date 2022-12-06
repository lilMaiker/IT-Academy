using FriendsMVC.Buisness.Contract.Interfaces;

namespace FriendsMVC.Buisness.Services
{
    public class StubFriendService : IFriendService
    {
        public Task<List<DataAccess.Models.Friend>> GetFriends()
        {
            return null;
        }
    }
}
