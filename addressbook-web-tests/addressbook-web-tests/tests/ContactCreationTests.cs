using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            app.Contacts.InitContactCreation();
            ContactData contact = new ContactData("Vasya");
            contact.Lastname = "Pupkin";
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContactCreation();
            app.Auth.Logout();
        }
    }
}
