using Microsoft.AspNetCore.Mvc;
using PhoneBook.Domain.Contrants.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonRepository personRepository;
        public HomeController(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        public IActionResult Index()
        {
        
            return View();
        }
    }
}
