using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.EndPoints.Mvc.Models.AAA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.Mvc.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<MyIdentityRole> roleManager;
        public RoleController(RoleManager<MyIdentityRole> roleManager )
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var list = roleManager.Roles.ToList();
            return View(list);
        }

        public IActionResult Create(string roleName)
        {
            MyIdentityRole role = new MyIdentityRole
            {
                Name = roleName
            };
            var result = roleManager.CreateAsync(role).Result;
            return RedirectToAction("Index");
        }
    }
}
