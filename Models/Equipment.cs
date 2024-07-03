using System.ComponentModel.DataAnnotations;

namespace RatMaintenance.Models
{
    public class Equipment
    {
        [Key]
        public int EquipmentId { get; set; }

        [Required]
        public string Name { get; set; }

        public string SerialNumber { get; set; }
    }
}
