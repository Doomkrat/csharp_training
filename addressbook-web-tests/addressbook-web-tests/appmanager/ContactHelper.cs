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
            if (!IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[2]/td/input")))
            {
                ContactData name = new ContactData("Mikki");
                name.Lastname = "Mouse";
                CreateContact(name);
            }
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
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            
        }
        
        public void InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        internal ContactHelper Remove()
        {
            if (!IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[2]/td/input")))
            {
                ContactData name = new ContactData("Mikki");
                name.Lastname = "Mouse";
                CreateContact(name);
            }
            SelectContact();
            RemoveContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        private ContactHelper RemoveContact()
        {
            
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        private ContactHelper SelectContact()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td/input")).Click();
            return this;
        }
        private ContactHelper CreateContact( ContactData newcontact)
        {
            InitContactCreation();
            ContactData contact = new ContactData("Vasya");
            contact.Lastname = "Pupkin";
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }
    }
}
