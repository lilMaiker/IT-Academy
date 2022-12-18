using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace FriendsMVC.Buisness.Contract.Models
{
    public class CountryViewModel
    {
        public int CountryID { get; set; }
        public string? CountryName { get; set; }
        public int Population { get; set; }
    }
}
