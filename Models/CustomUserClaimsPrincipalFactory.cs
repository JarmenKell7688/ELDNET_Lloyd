using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
namespace ELDNET_Lloyd.Models
{
    public class CustomUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<Student, AppRole>
    {
        public CustomUserClaimsPrincipalFactory(
        UserManager<Student> userManager,
        RoleManager<AppRole> roleManager,
        IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, roleManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Student user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            // Add your custom claims here
            identity.AddClaim(new Claim("FullName", $"{user.FirstName} {user.LastName}"));
            identity.AddClaim(new Claim("Course", user.Course ?? ""));
            identity.AddClaim(new Claim("Email", user.Email ?? ""));
            return identity;
        }
    }
}
