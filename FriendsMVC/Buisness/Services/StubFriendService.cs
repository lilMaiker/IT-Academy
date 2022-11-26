using FriendsMVC.Buisness.Contract.Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

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
