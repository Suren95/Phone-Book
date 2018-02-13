using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhoneBook.Models.Entities
{
    public class ContactType
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage ="This Field is Required")]
        [MaxLength(9, ErrorMessage = "Number must have  Length of 9")]
        [MinLength(9, ErrorMessage = "Number must have  Length of 9")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Telephone number must be numeric")]
        [Index(IsUnique = true)]
        public string PhoneNumber1 { get; set; }

        [MaxLength(9, ErrorMessage = "Number must have  Length of 9")]
        [MinLength(9, ErrorMessage = "Number must have  Length of 9")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Telephone number must be numeric")]
        public string PhoneNumber2 { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(30)]
        [Index( IsUnique = true)]
        public string EmailAddress { get; set; }

        public int ContactId { get; set; }

        [ForeignKey("ContactId")]
        public virtual Contact Contact { get; set; }   
    }
}