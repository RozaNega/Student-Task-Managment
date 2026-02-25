using System.ComponentModel.DataAnnotations;

namespace userapp.ViewModels
{
    public class ChangePassswordViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

       
        [Required(ErrorMessage = "Password is required")]
        
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 40 characters")]
        
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        
        [Compare("ConfirmNewPassword", ErrorMessage = "Password and confirm password do not match")]
        public string NewPassword { get; set; }

       
       [Required(ErrorMessage = "ConfirmNewpassword is required")]
       
        [DataType(DataType.Password)]
        
        [Display(Name = "ConfirmNewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
