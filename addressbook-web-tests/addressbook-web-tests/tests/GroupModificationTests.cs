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
   public class GroupModificationTests : AuthTestBase
    {

        [Test]
        public void GroupMofifcationTest()
        {
            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsElementPresent(By.XPath("(//input[@name='selected[]'])[1]")))
            {
                GroupData group = new GroupData("aaa");
                group.Header = "test header";
                group.Footer = "test footer";
                app.Groups.Create(group);
            }
            GroupData newData = new GroupData("bbb");
            newData.Header = null;
            newData.Footer = null;
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }

        }
    }
}
