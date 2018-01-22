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
                    FirstName = GenerateRandomString(20),
                    LastName = GenerateRandomString(20)
                };
                app.Contacts.CreateContact(name);
            }
            ContactData newData = new ContactData()
            {
                FirstName = "Jonny",
                LastName = "Mnemonik"
            };
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];
            app.Contacts.Modify(newData);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0] = newData;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach(ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData,contact);
                }
            }

        }

    }
}
