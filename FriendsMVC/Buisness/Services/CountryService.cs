using FriendsMVC.Buisness.Contract.Interfaces;
using FriendsMVC.DataAccess;

using Microsoft.EntityFrameworkCore;

using System.ComponentModel;

namespace FriendsMVC.Buisness.Services
{
    public class CountryService : ICountryService
    {
        private ApplicationDbContext _dbContext;
        public CountryService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public Task<List<DataAccess.Models.Country>> GetCountries()
        {
            return _dbContext.Countries.ToListAsync();
        }

        public Task<List<DataAccess.Models.Country>> GetCountries(string pCountry)
        {
            return _dbContext.Countries.Where(p => p.CountryName == pCountry).ToListAsync();
        }

        public Task<List<DataAccess.Models.Country>> GetCountries(string pCountry, string[] ctites)
        {
            return _dbContext.Countries.Where(p => p.CountryName == pCountry && ctites.Contains(p.CityForCountry)).ToListAsync();
        }

        public DbSet<DataAccess.Models.Country> Countries()
        {
            return _dbContext.Countries;
        }

        public void AddNewCountry(DataAccess.Models.Country country)
        {
            _dbContext.Add(country);
        }

        public void UpdateCountry(DataAccess.Models.Country country)
        {
            _dbContext.Update(country);
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
