using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
   public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupMofifcationTest()
        {
            GroupData newData = new GroupData("bbb");
            newData.Header = "modified header";
            newData.Footer = "modified footer";
            app.Groups.Modify(1, newData);

        }
    }
}
