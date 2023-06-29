using DiplomaProject.Core;
using DiplomaProject.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject.Tests
{
    public class LoginTest
    {

        protected IWebDriver _driver;

        [SetUp]
        public void SetUp() 
        {
            _driver = new Browser().Driver; 
                
        }

        [Test]
        public void SuccessfulLoginTest()
        {
            var loginPage = new LoginPage(_driver, true);

            loginPage.EmailInput.SendKeys("krukelenka84@gmail.com");
            loginPage.PasswordInput.SendKeys("krukelenka84");
            loginPage.LoginButton.Click();

            Thread.Sleep(3000);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }

    }
}
