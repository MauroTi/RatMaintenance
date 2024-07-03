using System.ComponentModel.DataAnnotations;

namespace RatMaintenance.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Role { get; set; } // Technician or Client
    }
}
