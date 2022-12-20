using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FriendsMVC.DataAccess.Models
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }

        [Column(TypeName = "VARCHAR(45)")]
        [DisplayName("Название страны")]
        [Required]
        public string? CountryName { get; set; }

        [Column(TypeName = "VARCHAR(45)")]
        [DisplayName("Название города")]
        public string? CityForCountry { get; set; }

        [Column(TypeName = "VARCHAR(45)")]
        [DisplayName("Размер населения")]
        [Required]
        public int Population { get; set; }
    }
}
