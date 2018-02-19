using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProgectManagmentHelper : HelperBase
    {
        public ProgectManagmentHelper(ApplicationManager manager) : base(manager) { }

        public void SubmitProgectCreation()
        {
           
            driver.FindElement(By.CssSelector("div.widget-toolbox input.btn-primary")).Click();
            driver.FindElement(By.LinkText("Proceed")).Click();
        }

        public void CreateIfNoProgectsPresent()
         {
             manager.Navigator.GoToProgectTab();
 
             if (!IsElementPresent(By.XPath("//table[1]/tbody/tr")))
             {
                 ProgectData progect = new ProgectData()
                 {
                     Name = $"Progect{DateTime.Now.Ticks}",
                     Description = ""
                 };
 
                 Create(progect);
             }
 
         }
 
         public void Create(ProgectData progect)
         {
             manager.Navigator.GoToProgectTab();
             InitProgectCreation();
             FillProgectForm(progect);
             SubmitProgectCreation();
         }
        public void InitProgectCreation()
         {
            driver.FindElement(By.CssSelector("button.btn.btn-primary.btn-white.btn-round")).Click();
         }
 
         public void FillProgectForm(ProgectData progect)
         {
             Type(By.Id("project-name"), progect.Name);
             Type(By.Id("project-description"), progect.Description);
         }
 
         public void Remove(ProgectData progect)
         {
             manager.Navigator.GoToProgectTab();
             OpenEditPage(progect.Name);
             RemoveProgect();
             SubmitProgectRemove();
         }
 
         public void OpenEditPage(String name)
         {
             driver.FindElement(By.LinkText(name)).Click();
         }
 
         public void RemoveProgect()
         {
             driver.FindElement(By.CssSelector("form#project-delete-form input.btn")).Click();
         }
 
         public void SubmitProgectRemove()
         {
             driver.FindElement(By.CssSelector("div.alert-warning .btn")).Click();
         }
 
         public void DeleteIfSuchProgectExist(ProgectData progect)
         {
             manager.Navigator.GoToProgectTab();
 
             if (IsElementPresent(By.XPath("//table[1]/tbody/tr/td[1]/a[.='"+ progect.Name + "']")))
             {
                 Remove(progect);
             }
         }


        public List<ProgectData> GetProgectList()
        {
            List<ProgectData> list = new List<ProgectData>();
            manager.Navigator.GoToProgectTab();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector(".table"))[0]
                .FindElements(By.CssSelector("tbody>tr"));
            foreach (IWebElement element in elements)
            {
                list.Add(new ProgectData()
                {
                    Name = element.FindElements(By.CssSelector("td"))[0].Text,
                    Description = element.FindElements(By.CssSelector("td"))[4].Text
                });
            }
            return list;
        }

        public int GetProgectCount()
        {
            manager.Navigator.GoToProgectTab();
            return driver.FindElements(By.CssSelector(".table"))[0]
                .FindElements(By.CssSelector("tbody>tr"))
                .Count();
        }
    }
}
