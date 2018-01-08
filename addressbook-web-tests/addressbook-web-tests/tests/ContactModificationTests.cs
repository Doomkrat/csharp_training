using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests.tests
{
    [TestFixture]
   public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactMofifcationTest()
        {
            if (!app.Contacts.IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[2]/td/input")))
            {
                ContactData name = new ContactData()
                {
                    FirstName = "Mikki",
                    LastName = "Mouse"
                };
                app.Contacts.CreateContact(name);
            }
            ContactData newcontact
                = new ContactData()
            {
                FirstName = "Jonny",
                LastName = "Mnemonik"
            };
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Modify(newcontact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0] = newcontact;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }

    }
}
