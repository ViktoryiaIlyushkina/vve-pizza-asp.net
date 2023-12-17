using Microsoft.AspNetCore.Identity;

namespace VVE_Pizza.Models
{
    public class User: IdentityUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

}
