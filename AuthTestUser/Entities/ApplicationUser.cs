using Microsoft.AspNetCore.Identity;
using System;

namespace AuthTestUser.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public User? Users{ get; set; }
    }
}
