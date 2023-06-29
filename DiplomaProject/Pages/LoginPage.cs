using DiplomaProject.Wrappers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject.Pages
{
    public class LoginPage : BasePage
    {
        private static readonly By EmailInputBy = By.Name("email");
        private static readonly By PasswordInputBy = By.Name("password");
        private static readonly By RememberMeCheckboxBy = By.Name("remember");
        private static readonly By LoginButtonBy = By.XPath("//button[text()='Log in']");


        public LoginPage(IWebDriver driver, bool openPageByURL = false) : base(driver, openPageByURL)
        {
        }

        public override bool IsPageOpened => _waitService.GetVisibleElement(LoginButtonBy) != null;

        protected override string Endpoint => "auth/login";


        public Input EmailInput => new Input(_driver.FindElement(EmailInputBy));

        public Input PasswordInput => new Input(_driver.FindElement(PasswordInputBy));

        public IWebElement RememberMeCheckbox => _driver.FindElement(RememberMeCheckboxBy);

        public Button LoginButton => new Button(_driver.FindElement(LoginButtonBy));
    }
}
