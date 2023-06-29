using DiplomaProject.Utilities.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject.Core
{
    public class Browser : IDisposable
    {
        public Browser()
        {
            Driver = Configurator.Browser?.ToLower() switch
            {
                "chrome" => new DriverFactory().GetChromeDriver(),
                _ => Driver
            };

            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();
            if (Driver != null) Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public IWebDriver Driver { get; set; }

        public void Dispose()
        {
            Driver?.Dispose();
        }
    }
}

