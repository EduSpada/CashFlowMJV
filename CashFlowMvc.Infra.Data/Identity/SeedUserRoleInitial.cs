using CashFlowMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CashFlowMvc.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager,
                                   RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("usuario@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "usuario@localhost";
                user.Email = "usuario@localhost";
                user.NormalizedUserName = "USUARIO@LOCALHOST";
                user.NormalizedEmail = "USUARIO@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "UmASenh@F04t3").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
            if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin@localhost";
                user.Email = "admin@localhost";
                user.NormalizedUserName = "ADMIN@LOCALHOST";
                user.NormalizedEmail = "ADMIN@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "UmASenh@F04t3").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
            if (_userManager.FindByEmailAsync("employer@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "employer@localhost";
                user.Email = "employer@localhost";
                user.NormalizedUserName = "EMPLOYER@LOCALHOST";
                user.NormalizedEmail = "EMPLOYER@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "UmASenh@F04t3").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Employer").Wait();
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
            if (_userManager.FindByEmailAsync("manager@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "manager@localhost";
                user.Email = "manager@localhost";
                user.NormalizedUserName = "MANAGER@LOCALHOST";
                user.NormalizedEmail = "MANAGER@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "UmASenh@F04t3").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Manager").Wait();
                    _userManager.AddToRoleAsync(user, "Employer").Wait();
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
        }
        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Manager").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Manager";
                role.NormalizedName = "MANAGER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Employer").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Employer";
                role.NormalizedName = "EMPLOYER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }


    }
}
