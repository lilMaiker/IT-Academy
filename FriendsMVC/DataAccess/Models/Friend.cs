using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace FriendsMVC.DataAccess.Models
{
    public class Friend
    {
        [Key]
        public int FriendID { get; set; }

        [Column(TypeName = "VARCHAR(45)")]
        [DisplayName("Имя друга")]
        [Required]
        public string FriendName { get; set; }

        [Column(TypeName = "VARCHAR(45)")]
        [DisplayName("Место знакомства")]
        [Required]
        public string Place { get; set; }
    }
}
