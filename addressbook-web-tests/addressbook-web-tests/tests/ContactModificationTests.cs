using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
   public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactMofifcationTest()
        {
            ContactData newcontact = new ContactData("Jonny");
            newcontact.Lastname = "Mnemonik";
            app.Contacts.Modify(2, newcontact);

        }

    }
}
