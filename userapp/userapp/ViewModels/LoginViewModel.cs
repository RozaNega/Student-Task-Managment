using System.ComponentModel.DataAnnotations;

namespace userapp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage =  "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
           public bool RememberMe { get; set; }
        
        // Optional role selector for role-specific login pages (e.g. Admin, Storeman, Employee, Customer)
        public string? Role { get; set; }
    }
}
