namespace FriendsMVC.Buisness.Contract.Interfaces
{
    public interface IFriendService
    {
        public Task<List<DataAccess.Models.Friend>> GetFriends();
        
    }
}
