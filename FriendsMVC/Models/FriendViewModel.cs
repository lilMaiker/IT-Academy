using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace FriendsMVC.Models
{
    public class FriendViewModel
    {
        public int FriendID { get; set; }
        public string FriendName { get; set; }
        public string Place { get; set; }
    }
}
