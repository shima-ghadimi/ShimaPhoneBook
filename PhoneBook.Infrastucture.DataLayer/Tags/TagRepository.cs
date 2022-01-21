using PhoneBook.Domain.Contrants.Tags;
using PhoneBook.Domain.Core.Tags;
using PhoneBook.Infrastucture.DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrastucture.DataLayer.Tags
{
    public class TagRepository :BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(PhoneBookContext db): base(db)
        {

        }
    }
}
