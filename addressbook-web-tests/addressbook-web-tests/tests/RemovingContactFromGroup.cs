using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
   public class RemovingContactFromGroup:AuthTestBase
    {
        [SetUp]
        public void SetupGroupRemovalTest()
        {
            app.Groups.CheckGroupExist();
            app.Contacts.CheckContactExist();
        }

        [Test]
        public void TestRemovingContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            app.Contacts.CheckAllContactsExist(group);
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = group.GetContacts().First();

            

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList.Count-1, newList.Count);
        }
    }
}
