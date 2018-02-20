using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Firefox;

namespace mantis_tests
{
    public class AdminHelper:HelperBase
    {
        private string baseUrl;

        public AdminHelper(ApplicationManager manager, String baseUrl) : base(manager)
        {
            this.baseUrl = baseUrl;
        }

        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_page.php";
            IList<IWebElement> rows = driver.FindElement(By.CssSelector("table.table.table-striped.table-bordered." +
                "table-condensed.table-hover")).FindElements(By.XPath(".//tbody/tr"));
            foreach(IWebElement row in rows)
            {
              IWebElement link =  row.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;

                accounts.Add(new AccountData()
                {
                    Name = name, Id = id
                });
            }
            return accounts;
        }

        public void DeleteAccount(AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_edit_page.php?user_id=" + account.Id;
            driver.FindElement(By.CssSelector("input[value='Delete User']")).Click();
            driver.FindElement(By.CssSelector("input[value='Delete Account']")).Click();
        }

        private IWebDriver OpenAppAndLogin()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArguments("headless", "disable-gpu", "remote-debugging-port=9222", "window-size=1440,900",
                "disable-infobars", "--disable-extensions");
            options.BrowserExecutableLocation = @"C:\temp\firefox-sdk\bin\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            driver.Url = baseUrl + "/login_page.php";
            driver.FindElement(By.CssSelector("input#username")).SendKeys("administrator");
            driver.FindElement(By.CssSelector("input.width-40.pull-right.btn.btn-success.btn-inverse.bigger-110")).Click();

            driver.FindElement(By.Name("password")).SendKeys("root");
            driver.FindElement(By.CssSelector("input.width-40.pull-right.btn")).Click();

            return driver;
        }
    }
}
