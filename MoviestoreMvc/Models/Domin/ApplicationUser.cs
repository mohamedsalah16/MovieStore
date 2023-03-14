using Microsoft.AspNetCore.Identity;

namespace MoiveStoreMvc.Models.Domin
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}