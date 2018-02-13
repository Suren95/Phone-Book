using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhoneBook.Models.Entities
{
    public class Contact
    {
        public Contact()
        {
            ContactType = new HashSet<ContactType>();
        }
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "ContactName must have min length of 1 and max Length of 20")]

        public string ContactName { get; set; }

        public virtual ICollection<ContactType> ContactType { get; set; }
    }
}