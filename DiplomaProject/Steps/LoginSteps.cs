using DiplomaProject.Models;
using DiplomaProject.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject.Steps
{
    public class LoginSteps : BaseStep
    {
        public LoginSteps(IWebDriver driver) : base(driver)
        {
            LoginPage = new LoginPage(driver);
            HomePage = new HomePage(driver);
        }

        public LoginPage LoginPage;
        public HomePage HomePage;

       
        public HomePage SuccessfulLogin(User user)
        {
            Login(user);


            return HomePage;
        }
        public LoginPage NegativeLogin(User user)
        {
            Login(user);

            return LoginPage;
        }

        private void Login (User user)
        {
            LoginPage.OpenPageByURL();

            LoginPage.EmailInput.SendKeys(user.Login);
            LoginPage.PasswordInput.SendKeys(user.Password);
            LoginPage.LoginButton.Click();
        } 
    }
}