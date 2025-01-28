using Microsoft.AspNetCore.Identity;
using System;

public class ApplicationUser : IdentityUser
{
    public DateTime? RegistrationDate { get; set; }
}
