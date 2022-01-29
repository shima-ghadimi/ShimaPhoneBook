using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.Mvc.Models.AAA
{
    public class MyUserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            List<IdentityError> errors = new List<IdentityError>();

            //if (!user.Email.EndsWith("@nikamooz.com"))
            //{
            //    errors.Add(new IdentityError
            //    {
            //        Code = "InvalidEmail",
            //        Description = "Use nikamooz email for Registration"
            //    });
            //}

            return Task.FromResult(errors.Any() ?
                    IdentityResult.Failed(errors.ToArray()) :
                    IdentityResult.Success);
        }
    }
}
