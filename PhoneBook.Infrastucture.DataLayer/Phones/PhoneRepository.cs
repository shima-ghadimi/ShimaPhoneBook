using PhoneBook.Domain.Contrants.Phones;
using PhoneBook.Domain.Core.Phones;
using PhoneBook.Infrastucture.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrastucture.DataLayer.Phones
{
    public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(PhoneBookContext db): base(db)
        {
                
        }
    }
}
