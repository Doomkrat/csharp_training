using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;



namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.InitContactCreation();
            ContactData contact = new ContactData()
            {
                FirstName = "Vasya",
                LastName = "Pupkin"
        };
            
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContactCreation();
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
