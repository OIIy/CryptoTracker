using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoTracker.Api.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(65)")]
        public string Username { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public byte[] PasswordHash { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public byte[] PasswordSalt { get; set; }
    }
}
