using Microsoft.AspNetCore.Identity;

namespace userapp.Models
{
    public class users: IdentityUser

    {
        public string? FullName { get; set; }
    }
}
