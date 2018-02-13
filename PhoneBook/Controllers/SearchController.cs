using PhoneBook.Models;
using PhoneBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook.Controllers
{
    public class SearchController : Controller
    {
        PhoneBookEntity dbContext = new PhoneBookEntity();

        // GET: Search
        public ActionResult Index(string name)
        {
            var contacts = (from contact in dbContext.Contacts
                            join contactType in dbContext.ContactType
                            on contact.ContactId equals contactType.ContactId
                            select new PhoneModel
                            {
                                Id = contactType.Id,
                                ContactId = contact.ContactId,
                                ContactName = contact.ContactName,
                                PhoneNumber1 = contactType.PhoneNumber1,
                                PhoneNumber2 = contactType.PhoneNumber2,
                                EmailAddress = contactType.EmailAddress
                            }).ToList();

            var result = contacts.Where(w => w.ContactName.ToUpper().Contains(name.ToUpper())).ToList();

            var Result = result.Where(w => w.ContactName.ToUpper().StartsWith(name.ToUpper()));
            return View(Result);
        }


      
    }
}