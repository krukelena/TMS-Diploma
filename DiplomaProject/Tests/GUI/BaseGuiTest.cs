using Allure.Commons;
using DiplomaProject.Core;
using DiplomaProject.Steps;
using NLog;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject.Tests.UI
{
    public abstract class BaseGuiTest : BaseTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [ThreadStatic] protected static IWebDriver? _driver;
        protected LoginSteps _loginSteps;
        protected ProjectSteps _projectSteps;
        private AllureLifecycle _allure;


        [SetUp]
        public void Setup()
        {
            _logger.Trace("Setup");

            _driver = new Browser().Driver;
            _loginSteps = new LoginSteps(_driver);
            _projectSteps = new ProjectSteps(_driver);
            _allure = AllureLifecycle.Instance;
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                _allure.AddAttachment(name: "Screenshot", type: "image/png", screenshotBytes);
            }
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
