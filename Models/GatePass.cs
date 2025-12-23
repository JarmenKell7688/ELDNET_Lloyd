using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELDNET_Lloyd.Models
{
    public class GatePass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Pending";

        [Required(ErrorMessage = "School year is required.")]
        [StringLength(10)]
        public string SchoolYear { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        [StringLength(20)]
        public string Type { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        [StringLength(70)]
        public string Department { get; set; }

        [Required(ErrorMessage = "Course year is required.")]
        [StringLength(30)]
        public string CourseYear { get; set; }

        [Required(ErrorMessage = "Vehicle plate number is required.")]
        [StringLength(15)]
        public string VehiclePlateNo { get; set; }

        [Required(ErrorMessage = "Registration expiry date is required.")]
        public DateTime? RegistrationExpiry { get; set; }

        [Required(ErrorMessage = "Vehicle type is required.")]
        [StringLength(15)]
        public string VehicleType { get; set; }

        [Required(ErrorMessage = "Maker is required.")]
        [StringLength(30)]
        public string Maker { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        [StringLength(25)]
        public string Color { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Documents are required.")]
        public List<IFormFile>? DocumentUploadFiles { get; set; }

        public string? DocumentFilesJson { get; set; } // store as JSON

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student? User { get; set; }
    }
}
