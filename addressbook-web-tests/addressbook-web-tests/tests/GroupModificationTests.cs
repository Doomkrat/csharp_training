using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;


namespace WebAddressbookTests
{
    [TestFixture]
   public class GroupModificationTests : GroupTestBase
    {
     

        [Test]
        public void GroupMofifcationTest()
        {
            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsElementPresent(By.XPath("(//input[@name='selected[]'])[1]")))
            {
                GroupData group = new GroupData(GenerateRandomString(10));
                group.Header = GenerateRandomString(10);
                group.Footer = GenerateRandomString(10);
                app.Groups.Create(group);
            }
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData newData = new GroupData(GenerateRandomString(10));
            newData.Header = GenerateRandomString(10);
            newData.Footer = GenerateRandomString(10);
            

            GroupData toBeModified = oldGroups[0];
            app.Groups.Modify(toBeModified,newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData group in newGroups)
            {
                if (group.Id == toBeModified.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }

        }
    }
}
