using System.ComponentModel.DataAnnotations;

namespace CryptoTracker.Api.Models
{
    public class BNC2Code
    {
        [Key]
        public int CodeId { get; set; }

        public string CodeName { get; set; }

        public string CodeDescription { get; set; }

    }
}