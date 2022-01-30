using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Domain.Contrants.People;
using PhoneBook.Domain.Contrants.Tags;
using PhoneBook.Domain.Core.People;
using PhoneBook.EndPoints.Mvc.Models.People;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.Mvc.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {
        private readonly ITagRepository tagRepository;
        private readonly IPersonRepository personRepository;

        public PeopleController(
            ITagRepository tagRepository,
            IPersonRepository personRepository
            )
        {
            this.tagRepository = tagRepository;
            this.personRepository = personRepository;
        }


        public IActionResult Index()
        {
            var allPerson = personRepository.List().ToList();

            return View(allPerson);
        }


        public IActionResult Add()
        {
            AddNewPersonDisplayViewModel model = new AddNewPersonDisplayViewModel();
            model.TagsForDisplay = tagRepository.List().ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(AddNewPersonGetViewModel person)
        {
            if (ModelState.IsValid)
            {
                var newPerson = new Person()
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Email = person.Email,
                    Address = person.Address,
                    Tags = new List<PersonTag>(person.SelectedTag.Select(x => new PersonTag() { TagId = x }))

                };
                if (person?.Image?.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        person.Image.CopyTo(ms);
                        var arr = ms.ToArray();
                        newPerson.Image = Convert.ToBase64String(arr);
                    }

                }
                personRepository.Add(newPerson);
                return RedirectToAction("Index");
            }

            AddNewPersonDisplayViewModel modelforDisplay = new AddNewPersonDisplayViewModel
            {
                Address = person.Address,
                Email = person.Email,
                LastName = person.LastName,
                FirstName = person.FirstName
            };
            modelforDisplay.TagsForDisplay = tagRepository.List().ToList();
            return View(modelforDisplay);
         
        }
    }
}
