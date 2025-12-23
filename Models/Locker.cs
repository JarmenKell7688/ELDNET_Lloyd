using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELDNET_Lloyd.Models
{
    public class Locker
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Pending";

        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "ID number is required.")]
        [StringLength(30)]
        public string IdNumber { get; set; }

        [Required(ErrorMessage = "Locker number is required.")]
        [StringLength(20)]
        public string LockerNumber { get; set; }

        [Required(ErrorMessage = "Semester is required.")]
        [StringLength(10)]
        public string Semester { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        [StringLength(20)]
        [Phone]
        public string ContactNumber { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Documents are required.")]
        public List<IFormFile>? DocumentUploadFiles { get; set; }

        public string? DocumentFilesJson { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student? User { get; set; }
    }
}
