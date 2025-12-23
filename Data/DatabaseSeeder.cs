using Microsoft.AspNetCore.Identity;
using ELDNET_Lloyd.Models;

namespace WebAppFinal.Data
{
    public class DatabaseSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<Student>>();

            // Create roles if they don't exist
            await CreateRoleIfNotExists(roleManager, "Admin");
            await CreateRoleIfNotExists(roleManager, "Student");

            // Create default admin user
            await CreateAdminUser(userManager);
        }

        private static async Task CreateRoleIfNotExists(RoleManager<AppRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new AppRole { Name = roleName });
                Console.WriteLine($"✅ Role '{roleName}' created successfully!");
            }
            else
            {
                Console.WriteLine($"ℹ️  Role '{roleName}' already exists.");
            }
        }

        private static async Task CreateAdminUser(UserManager<Student> userManager)
        {
            // Check if admin already exists
            var adminEmail = "admin@eldnet.com";
            var existingAdmin = await userManager.FindByEmailAsync(adminEmail);

            if (existingAdmin == null)
            {
                // Create default profile image (1x1 pixel transparent PNG)
                byte[] defaultImage = Convert.FromBase64String(
                    "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNk+M9QDwADhgGAWjR9awAAAABJRU5ErkJggg=="
                );

                var adminUser = new Student
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    FirstName = "System",
                    LastName = "Administrator",
                    Course = "N/A",
                    StudentImage = defaultImage
                };

                // Create user with password: Admin@123
                var result = await userManager.CreateAsync(adminUser, "Admin@123");

                if (result.Succeeded)
                {
                    // Add to Admin role
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                    Console.WriteLine("✅ Default admin account created successfully!");
                    Console.WriteLine($"   Email: {adminEmail}");
                    Console.WriteLine("   Password: Admin@123");
                }
                else
                {
                    Console.WriteLine("❌ Failed to create admin account:");
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"   - {error.Description}");
                    }
                }
            }
            else
            {
                Console.WriteLine("ℹ️  Admin account already exists.");
            }
        }
    }
}