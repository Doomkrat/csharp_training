using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
   public class ContactModificationTests : ContactTestBase
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
            List<ContactData> oldContacts = ContactData.GetAll();
            foreach (ContactData contact in oldContacts)
            { System.Console.Out.WriteLine("old " + contact.FirstName + " " + contact.LastName); }
            ContactData toBeModified = oldContacts[0];

            app.Contacts.Modify(newData, toBeModified);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            foreach (ContactData contact in newContacts)
            { System.Console.Out.WriteLine("new " + contact.FirstName + " " + contact.LastName); }

            oldContacts[0] = newData;
            foreach (ContactData contact in oldContacts)
            { System.Console.Out.WriteLine("oldmodified " + contact.FirstName + " " + contact.LastName); }

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == toBeModified.Id)
                {
                    Assert.AreEqual(newData.FirstName, contact.FirstName);
                    Assert.AreEqual(newData.LastName, contact.LastName);
                }
            }

        }

    }
}
