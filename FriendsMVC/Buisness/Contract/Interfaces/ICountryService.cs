using Microsoft.EntityFrameworkCore;

namespace FriendsMVC.Buisness.Contract.Interfaces
{
    public interface ICountryService
    {
        public Task<List<DataAccess.Models.Country>> GetCountries();
        public Task<List<DataAccess.Models.Country>> GetCountries(string pCountry);
        public Task<List<DataAccess.Models.Country>> GetCountries(string pCountry, string[] cities);
        public DbSet<DataAccess.Models.Country> Countries();
        public void AddNewCountry(DataAccess.Models.Country country);
        public void UpdateCountry(DataAccess.Models.Country country);
        public Task<int> SaveChangesAsync();
    }
}
