namespace PhoneBook.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PhoneBookEntity : DbContext
    {
        public PhoneBookEntity()
            : base("name=PhoneBookEntity")
        {
        }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactType> ContactType { get; set; }
    }
}
