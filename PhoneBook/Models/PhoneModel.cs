using PhoneBook.Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBook.Models
{
    public class PhoneModel 
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string EmailAddress { get; set; }

    }
}