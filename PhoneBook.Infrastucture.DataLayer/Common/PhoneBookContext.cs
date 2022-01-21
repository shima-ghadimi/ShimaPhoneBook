using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Core.People;
using PhoneBook.Domain.Core.Phones;
using PhoneBook.Domain.Core.Tags;
using PhoneBook.Infrastructure.DataLayer.People;
using PhoneBook.Infrastructure.DataLayer.Phones;
using PhoneBook.Infrastructure.DataLayer.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrastucture.DataLayer.Common
{
    public class PhoneBookContext:DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<PersonTag> personTags { get; set; }
        public DbSet<Phone> phones { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public PhoneBookContext(DbContextOptions<PhoneBookContext> option):base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new PersonTagConfig());
            modelBuilder.ApplyConfiguration(new PhoneConfig());
            modelBuilder.ApplyConfiguration(new TagConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
