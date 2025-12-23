using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELDNET_Lloyd.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Pending";

        [Required(ErrorMessage = "Organization name is required.")]
        [StringLength(60)]
        public string OrganizationName { get; set; }

        [Required(ErrorMessage = "Activity title is required.")]
        [StringLength(100)]
        public string ActivityTitle { get; set; }

        [Required(ErrorMessage = "Venue is required.")]
        [StringLength(60)]
        public string Venue { get; set; }

        [Required(ErrorMessage = "Date needed is required.")]
        [DataType(DataType.Date)]
        public DateTime? DateNeeded { get; set; }

        [Required(ErrorMessage = "Start time is required.")]
        [DataType(DataType.Time)]
        public TimeSpan TimeFrom { get; set; }

        [Required(ErrorMessage = "End time is required.")]
        [DataType(DataType.Time)]
        public TimeSpan TimeTo { get; set; }

        [Required(ErrorMessage = "Participants field is required.")]
        [StringLength(100)]
        public string Participants { get; set; }

        [Required(ErrorMessage = "Speaker is required.")]
        [StringLength(60)]
        public string Speaker { get; set; }

        [Required(ErrorMessage = "Purpose is required.")]
        [StringLength(500)]
        public string Purpose { get; set; }

        [Required(ErrorMessage = "Equipment needed is required.")]
        [StringLength(500)]
        public string EquipmentNeeded { get; set; }

        [Required(ErrorMessage = "Nature of activity is required.")]
        [StringLength(70)]
        public string NatureOfActivity { get; set; }

        [Required(ErrorMessage = "Source of funds is required.")]
        [StringLength(70)]
        public string SourceOfFunds { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student? User { get; set; }

        public byte[]? FileData { get; set; } // stores uploaded document(s)
    }
}
