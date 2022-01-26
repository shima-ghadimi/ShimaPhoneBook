using Microsoft.AspNetCore.Http;
using PhoneBook.Domain.Core.Tags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.Mvc.Models.People
{
    public abstract class AddNewPersonViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        public IFormFile Image { get; set; }
    }
    public class AddNewPersonDisplayViewModel : AddNewPersonViewModel
    {

        public List<Tag> TagsForDisplay { get; set; }
    }

    public class AddNewPersonGetViewModel : AddNewPersonViewModel
    {
        public List<int> SelectedTag { get; set; }
    }
}
   

