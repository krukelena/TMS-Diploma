using DiplomaProject.Core;
using DiplomaProject.Steps;
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

        [ThreadStatic] protected static IWebDriver? _driver;
        protected LoginSteps _loginSteps;
        protected ProjectSteps _projectSteps;


        [SetUp]
        public void Setup()
        {
            _driver = new Browser().Driver;
            _loginSteps = new LoginSteps(_driver);
            _projectSteps = new ProjectSteps(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }

    }
}
