namespace FriendsMVC.Buisness.Contract.Interfaces
{
    public interface ICountryService
    {
        public Task<List<DataAccess.Models.Country>> GetCountries();
        public Task<List<DataAccess.Models.Country>> GetCountries(string pCountry);
        public Task<List<DataAccess.Models.Country>> GetCountries(string pCountry, string[] cities);
    }
}
