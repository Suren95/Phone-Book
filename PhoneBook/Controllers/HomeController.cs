using PhoneBook.Models;
using PhoneBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace PhoneBook.Controllers
{
    public class HomeController : Controller
    {
        PhoneBookEntity dbContext = new PhoneBookEntity();
        public ActionResult Index()
        {
            var result = GetContact();
            return View(result);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Message = "Error";
                return View();
            }
            var contact = GetContact().Where(w => w.ContactId == id).FirstOrDefault();
            return View(contact);
        }

        [HttpPost]
        public ActionResult EditContact(PhoneModel model)
        {
            if (!string.IsNullOrEmpty(model.PhoneNumber1) && model.PhoneNumber1 == model.PhoneNumber2)
            {

                return View("Error");
            }

            if (IsContains(model.PhoneNumber1, model.PhoneNumber2))
            {
                return View("Error");

            }
            try
            {

                Contact contact = new Contact();
                
                contact.ContactId = model.ContactId;
                contact.ContactName = model.ContactName;

                ContactType contactType = new ContactType();
                contactType.Id = model.Id;
                contactType.ContactId = model.ContactId;
                contactType.EmailAddress = model.EmailAddress;
                contactType.PhoneNumber1 = model.PhoneNumber1;
                contactType.PhoneNumber2 = model.PhoneNumber2;

              //  dbContext.ContactType.AddOrUpdate(contactType);
                dbContext.Entry(contactType).State = EntityState.Modified;
                //  dbContext.Contacts.AddOrUpdate(contact);
               
                dbContext.Entry(contact).State = EntityState.Modified;

                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
       
        public ActionResult DeleteContact(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            try
            {
                var getContact = dbContext.Contacts.Find(id);
                dbContext.Contacts.Remove(getContact);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Add()
        {

            ViewBag.text3 = TempData["message3"];
            ViewBag.text4 = TempData["message4"];
            ViewBag.text5 = TempData["message5"];

            return View();
        }

        [HttpPost]
        public ActionResult AddContact(PhoneModel model)
        {

            if (model.PhoneNumber1 != null)
            {
                model.PhoneNumber1 = GetNumber(model.PhoneNumber1);
            }

            if (model.PhoneNumber2 != null)
            {
                model.PhoneNumber2 = GetNumber(model.PhoneNumber2);
            }


            if (!string.IsNullOrEmpty(model.PhoneNumber1) && model.PhoneNumber1 == model.PhoneNumber2)
            {
                TempData["message3"] = "The numbers are same";
                return RedirectToAction("Add");
            }

            if (IsContains(model.PhoneNumber1, model.PhoneNumber2))
            {
                TempData["message4"] = "This Number Already Exist";
                return RedirectToAction("Add");

            }

            try
            {
                Contact contact = new Contact();
                contact.ContactName = model.ContactName;
                contact.ContactType.Add(new ContactType
                {
                    PhoneNumber1 = model.PhoneNumber1,
                    PhoneNumber2 = model.PhoneNumber2,
                    EmailAddress = model.EmailAddress
                });
                dbContext.Contacts.Add(contact);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["message5"] = "Incorrect Input";
                return RedirectToAction("Add");
            }
        }
        public  List<PhoneModel> GetContact()
        {
            var dbResult = (from contact in dbContext.Contacts
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
            var result = dbResult.OrderBy(o => o.ContactName).ToList();
            return result;
        }

        public string GetNumber(string str)
        {
            string[] s = str.Split(new char[] { '-' });
            str = string.Join("", s);
            return str;
        }

        public bool IsContains(string str1, string str2)
        {
            var item1 = dbContext.ContactType.Where(s => s.PhoneNumber1.Contains(str2)).FirstOrDefault();
            var item2 = dbContext.ContactType.Where(s => s.PhoneNumber2.Contains(str1)).FirstOrDefault();
            if (item1 != null || item2 != null)
            {
                return true;
            }
            else
                return false;

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}