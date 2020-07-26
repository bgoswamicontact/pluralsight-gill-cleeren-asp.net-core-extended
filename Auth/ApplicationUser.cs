using Microsoft.AspNetCore.Identity;
using System;


namespace BethenysPieShop.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
