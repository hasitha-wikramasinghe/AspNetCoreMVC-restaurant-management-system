using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Fiverr_Sample.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "NIC")]
        public string? NIC { get; set; } = string.Empty;

        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; } 

    }
}
