using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.Mvc.Models.AAA
{
    public class MyPasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if (user.UserName == password || user.UserName.Contains(password))
            {
                errors.Add(new IdentityError() { Code = "Password", Description = "Usename is equal with Password" });
            }
      
            return Task.FromResult(errors.Any() ?
              IdentityResult.Failed(errors.ToArray()) :
              IdentityResult.Success
              );
        }
    }

    public class MyPasswordValidator2 : PasswordValidator<AppUser>
    {
        
        public override Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();
            var parentError =base.ValidateAsync(manager,user,password) ;
            if (!parentError.Result.Succeeded)
            {
                errors = parentError.Result.Errors.ToList();
            }
            if (user.UserName == password || user.UserName.Contains(password))
            {
                errors.Add(new IdentityError() { Code = "Password", Description = "Usename is equal with Password" });
            }

            return Task.FromResult(errors.Any() ?
              IdentityResult.Failed(errors.ToArray()) :
              IdentityResult.Success
              );
        }
    }
}
