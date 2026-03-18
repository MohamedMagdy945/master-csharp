using Microsoft.AspNetCore.Identity;

namespace ApiSrc.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FullName { get; set; }
    }

    public class IdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // 🔹 Register User
        public async Task<string> RegisterAsync(string email, string password, string fullName)
        {
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FullName = fullName
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                return string.Join(", ", result.Errors);

            return "User Registered Successfully";
        }

        // 🔹 Login
        public async Task<string> LoginAsync(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(
                email, password, false, false);

            if (!result.Succeeded)
                return "Invalid Login";

            return "Login Successful";
        }

        // 🔹 Create Role
        public async Task<string> CreateRoleAsync(string roleName)
        {
            if (await _roleManager.RoleExistsAsync(roleName))
                return "Role already exists";

            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));

            return result.Succeeded ? "Role Created" : "Error creating role";
        }

        // 🔹 Assign Role to User
        public async Task<string> AddUserToRoleAsync(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return "User not found";

            var result = await _userManager.AddToRoleAsync(user, roleName);

            return result.Succeeded ? "Role assigned" : "Error assigning role";
        }
    }
}
