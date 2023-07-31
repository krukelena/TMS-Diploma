using Allure.Commons;
using DiplomaProject.Core;
using DiplomaProject.Pages;
using DiplomaProject.Steps;
using DiplomaProject.Utilities.Configuration;
using NLog;
using NUnit.Allure.Attributes;
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
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();


        [Test, Category("Positive")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User1")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Gui")]
        [AllureIssue(name: "ID_1")]
        [AllureTag("Smoke")]
        [AllureLink("https://elenkakruk.testmo.net/")]
        [Description("Успешная регистрация")]
        public void SuccessfulLoginTest()
        {
            _logger.Info("Test SuccessfulLoginTest started!");

            _loginSteps.SuccessfulLogin(Configurator.Instance.User);
           
            Assert.IsTrue(_loginSteps.HomePage.IsPageOpened);

            _logger.Info("Test SuccessfulLoginTest finished!");
        }

        [Test, Category("Negative")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User2")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Gui")]
        [AllureIssue(name: "ID_2")]
        [AllureTag("Smoke")]
        [AllureLink("https://elenkakruk.testmo.net/")]
        [Description("Не верные данные")]
        public void NegativeLoginTest()
        {
            _logger.Info("Test NegativeLoginTest started!");

            var user = Configurator.Instance.User;
            user.Password = "incorrect";

            _loginSteps.NegativeLogin(user);

            var errorBlock = _loginSteps.LoginPage.ErrorBlock;

            Assert.IsTrue(errorBlock != null);

            _logger.Info("Test NegativeLoginTest finished!");
        }
    }
}
