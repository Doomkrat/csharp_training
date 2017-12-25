using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            app.Contacts.InitContactCreation();
            ContactData contact = new ContactData("Vasya");
            contact.Lastname = "Pupkin";
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContactCreation();
        }
    }
}
