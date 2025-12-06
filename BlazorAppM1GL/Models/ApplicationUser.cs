using Microsoft.AspNetCore.Identity;

namespace BlazorAppM1GL.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public bool RememberMe { get; set; }
    }
}
