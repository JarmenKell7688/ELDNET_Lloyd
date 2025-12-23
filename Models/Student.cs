using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ELDNET_Lloyd.Models
{
    public class Student : IdentityUser<int>
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [Required, MaxLength(60)]
        public string Course { get; set; }

        [Required, EmailAddress]
        public override string Email { get; set; }

        [Required]
        public byte[]? StudentImage { get; set; }
    }
}
