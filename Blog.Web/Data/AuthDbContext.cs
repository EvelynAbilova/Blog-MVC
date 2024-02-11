using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Blog.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRoleId = "3b343424-d990-40de-9e5f-9cf348d02a0e";
            var superAdminRoleId = "82bea1e2-0a68-41b1-8709-865f75ed01ef";
            var userRoleId = "f7e2bdaa-d636-4000-a37b-d72481084a82";

            var roles = new List<IdentityRole> {
                new IdentityRole
            {
                Name = "admin",
                NormalizedName = "admin",
                Id = adminRoleId,
                ConcurrencyStamp = adminRoleId
            },
            new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SuperAdmin",
                Id = superAdminRoleId,
                ConcurrencyStamp= superAdminRoleId
            },
            new IdentityRole
            {
                Name = "user",
                NormalizedName= "user",
                Id = userRoleId,
                ConcurrencyStamp= userRoleId
            }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            var superAdminId = "87a32c39-94a6-43d4-86d6-c845b0c2474b";

            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin@blog.com",
                Email = "superadmin@blog.com",
                NormalizedEmail = "superadmin@blog.com".ToUpper(),
                NormalizedUserName = "superadmin@blog.com".ToUpper(),
                Id = superAdminId
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "superadmin@123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId ,
                    UserId = superAdminId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }

    }
}
