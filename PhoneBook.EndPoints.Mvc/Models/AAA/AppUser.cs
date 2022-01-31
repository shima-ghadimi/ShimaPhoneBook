using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.Mvc.Models.AAA
{

    public class AppUser: IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

    }

    public class MyIdentityRole:IdentityRole<int> {
    }
}
