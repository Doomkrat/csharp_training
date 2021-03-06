﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using mantis_tests.tests;

namespace mantis_tests
{
  public  class ApplicationManager : TestBase
    {
        protected IWebDriver driver;
        public string baseURL;

        private new static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
        private ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"C:\temp\firefox-sdk\bin\firefox.exe";
            options.UseLegacyImplementation = true;
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/mantisbt-2.11.1";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            Projects = new ProgectManagmentHelper(this);
            Auth = new LoginHelper(this);
            Navigator = new NavigationHelper(this);
            Admin = new AdminHelper(this, baseURL);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            API = new APIHelper(this);
        }

         ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url= newInstance.baseURL + "/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver {
            get
            {
                return driver;
            }
        }

        public RegistrationHelper Registration { get; }
        public FtpHelper Ftp { get; set; }
        public ProgectManagmentHelper Projects { get; set; }
        public LoginHelper Auth { get; set; }
        public NavigationHelper Navigator { get; private set; }
        public AdminHelper Admin { get; private set; }
        public JamesHelper James { get; private set; }
        public MailHelper Mail { get; private set; }
        public APIHelper API { get; private set; }
    }
}
