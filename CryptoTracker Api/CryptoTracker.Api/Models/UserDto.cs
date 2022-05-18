using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoTracker.Api.Models
{
    public class UserDto
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; } = string.Empty;
    }
}
