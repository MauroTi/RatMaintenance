using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RatMaintenance.Models
{
    public class RAT
    {
        [Key]
        public int RATId { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Equipment")]
        [Required]
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

        [Required(ErrorMessage = "Service Date is required")]
        public DateTime ServiceDate { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
