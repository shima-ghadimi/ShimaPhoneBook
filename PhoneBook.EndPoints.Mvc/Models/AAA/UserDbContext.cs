using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook.EndPoints.Mvc.Models.AAA
{
    public class UserDbContext : IdentityDbContext<AppUser, MyIdentityRole, int>
    {
        public DbSet<BadPassword> badPasswords { get; set; }
        public UserDbContext(DbContextOptions options): base(options)
        {

        }
    }
}
