using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoTracker.Api.Models.DataTransferObjects
{
    public class User_Dto
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Username { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; } = string.Empty;
    }
}
