using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WarehouseManager.Domain
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string LastName { get; set; }

        public ICollection<OwnerUser> OwnedCompanies { get; set; }

        public EmployeeUser Employer { get; set; }
    }
}
