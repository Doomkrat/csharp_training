using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;



namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsElementPresent(By.XPath("(//input[@name='selected[]'])[1]")))
            {
                GroupData group = new GroupData("aaa");
                group.Header = "test header";
                group.Footer = "test footer";
                app.Groups.Create(group);
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove();
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

