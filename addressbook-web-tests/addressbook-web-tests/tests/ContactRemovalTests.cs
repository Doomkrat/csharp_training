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
   public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
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
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove();
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
