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

        internal void Create(ProgectData progect)
        {
            manager.Navigation.OpenManagmentMenu();
            manager.Navigation.GoToProgectTab();
            driver.FindElements(By.CssSelector("button.btn.btn-primary"))[0].Click();
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(progect.Name);
            driver.FindElement(By.Id("project-description")).Clear();
            driver.FindElement(By.Id("project-description")).SendKeys(progect.Description);
            driver.FindElement(By.CssSelector("div.widget-toolbox input.btn-primary")).Click();
            //driver.FindElement(By.LinkText("Proceed")).Click();
        }


        internal List<ProgectData> GetProgectList()
        {
            List<ProgectData> list = new List<ProgectData>();
            manager.Navigation.OpenManagmentMenu();
            manager.Navigation.GoToProgectTab();
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

        internal int GetProgectCount()
        {
            manager.Navigation.OpenManagmentMenu();
            manager.Navigation.GoToProgectTab();
            return driver.FindElements(By.CssSelector(".table"))[0]
                .FindElements(By.CssSelector("tbody>tr"))
                .Count();
        }
    }
}
