using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]

        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]

        public void TestContactInformationDetail()
        {
            ContactData fromDetailForm = app.Contacts.GetContactInfoFromDetailForm(0);
            ContactData fromEditForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromEditForm.ContactInfo, fromDetailForm.ContactInfo);
        }
    }
}
