using DiplomaProject.Core;
using DiplomaProject.Pages;
using DiplomaProject.Steps;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject.Tests.UI
{
    public class LoginTest : BaseGuiTest
    {
        [Test, Category("Positive")]
        public void SuccessfulLoginTest()
        {
            _loginSteps.SuccessfulLogin(new Models.User
            {
                Login = "krukelenka84@gmail.com",
                Password = "krukelenka84"
            });

            Assert.IsTrue(_loginSteps.HomePage.IsPageOpened);
        }

        [Test, Category("Negative")]
        public void NegativeLoginTest()
        {
            _loginSteps.NegativeLogin(new Models.User
            {
                Login = "krukelenka84@gmail.com",
                Password = ""
            });

            Assert.IsFalse(_loginSteps.HomePage.IsPageOpened);
        }
    }
}
