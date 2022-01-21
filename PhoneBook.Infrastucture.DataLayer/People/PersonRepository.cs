using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Contrants.People;
using PhoneBook.Domain.Core.People;
using PhoneBook.Infrastucture.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrastucture.DataLayer.People
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(PhoneBookContext db): base(db)
        {

        }
    }
}
