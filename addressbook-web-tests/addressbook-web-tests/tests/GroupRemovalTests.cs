using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (!app.Groups.IsElementPresent(By.XPath("(//input[@name='selected[]'])[2]")))
            {
                GroupData group = new GroupData("aaa");
                group.Header = "test header";
                group.Footer = "test footer";
                app.Groups.Create(group);
            }
            app.Groups.Remove();
            
        }
    }
}

