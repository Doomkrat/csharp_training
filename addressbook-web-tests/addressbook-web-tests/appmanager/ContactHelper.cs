using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
   public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }


        public void SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        internal ContactHelper Modify(ContactData newcontact)
        {
            SelectContact();
            InitContactModification();
            FillContactForm(newcontact);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        private ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])")).Click();
            return this;
        }

        public void FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            
        }
        
        public void InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        internal ContactHelper Remove()
        {
            SelectContact();
            RemoveContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td/input")).Click();
            return this;
        }
        public ContactHelper CreateContact( ContactData newcontact)
        {
            InitContactCreation();
            ContactData contact = new ContactData()
            {
                FirstName = "Vasya",
                LastName = "Pupkin"
            };
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }
        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
            foreach (IWebElement element in elements)
            {
                string lastName = element.FindElement(By.XPath("td[3]")).Text;
                string firstName = element.FindElement(By.XPath("td[2]")).Text;

                contacts.Add(new ContactData(firstName,lastName));
            }
            return contacts;
        }
    }
}
