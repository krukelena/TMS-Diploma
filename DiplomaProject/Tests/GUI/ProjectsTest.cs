using DiplomaProject.Models;
using DiplomaProject.Pages;
using DiplomaProject.Steps;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject.Tests.UI
{
    public class ProjectsTest : BaseGuiTest
    {

        [Test]
        [Description("Check limit value 81 ")]
        public void CheckLimitValue_1()
        {
            var user = new User
            {
                Login = "krukelenka84@gmail.com",
                Password = "krukelenka84"
            };

            if (!_loginSteps.SuccessfulLogin(user).IsPageOpened)
                throw new Exception("Main page not opened!");

            var projectsPage = new ProjectsPage(_driver, true);
            projectsPage.AddProjectButton.Click();

            var summaryInput = projectsPage.SummaryTextArea;
            summaryInput.SendKeys(new string('_', 81));

            Assert.That(summaryInput.Value.Length, Is.EqualTo(80));
        }

        [Test]
        [Description("Check limit value 0 ")]
        public void CheckLimitValue_2()
        {
            var user = new User
            {
                Login = "krukelenka84@gmail.com",
                Password = "krukelenka84"
            };

            if (!_loginSteps.SuccessfulLogin(user).IsPageOpened)
                throw new Exception("Main page not opened!");

            var projectsPage = new ProjectsPage(_driver, true);
            projectsPage.AddProjectButton.Click();

            var summaryInput = projectsPage.SummaryTextArea;
            summaryInput.SendKeys("");

            Assert.That(summaryInput.Value.Length, Is.EqualTo(0));
        }


        [Test]
        public void CheckModalWindow()
        {
            try
            {
                var user = new User
                {
                    Login = "krukelenka84@gmail.com",
                    Password = "krukelenka84"
                };

                if (!_loginSteps.SuccessfulLogin(user).IsPageOpened)
                    throw new Exception("Main page not opened!");

                var projectsPage = new ProjectsPage(_driver, true);
                projectsPage.AddProjectButton.Click();

                var summaryInput = projectsPage.SummaryTextArea;

                if (summaryInput == null)
                    Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        [Test]
        public void AddProjectTest()
        {
            var user = new User
            {
                Login = "krukelenka84@gmail.com",
                Password = "krukelenka84"
            };

            if (!_loginSteps.SuccessfulLogin(user).IsPageOpened)
                throw new Exception("Main page not opened!");

            var model = new Project { Name = "TMS" };
            _projectSteps.AddProject(model);

            var tableElement = _driver.FindElement(By.XPath($"//tr[@data-name='{model.Name}']"));

            Assert.IsTrue(tableElement != null);
        }

        [Test]
        public void CheckTooltip()
        {
            try
            {
                var user = new User
                {
                    Login = "krukelenka84@gmail.com",
                    Password = "krukelenka84"
                };

                if (!_loginSteps.SuccessfulLogin(user).IsPageOpened)
                    throw new Exception("Main page not opened!");

                var projectsPage = new ProjectsPage(_driver, true);
                projectsPage.AddProjectButton.Click();
                projectsPage.DefaultAccessTooltip.Click();

                string content = projectsPage.DefaultAccessTooltip.GetAttribute("data-content");
                var tooltip = _driver.FindElement(By.XPath($"//div[text()='{content}']"));

                Assert.IsTrue(tooltip != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void SuccecfulLoadingFile()
        {
            var user = new User
            {
                Login = "krukelenka84@gmail.com",
                Password = "krukelenka84"
            };

            if (!_loginSteps.SuccessfulLogin(user).IsPageOpened)
                throw new Exception("Main page not opened!");

            var projectsPage = new ProjectsPage(_driver, true);
            projectsPage.AddProjectButton.Click();
            projectsPage.SelectButton.Click();
            projectsPage.SelectFileInput.SendKeys("C:\\Users\\Hp\\Pictures\\picture.png");

            var avatarSrc = projectsPage.CustomAvatarImage;
            Assert.IsTrue(avatarSrc != null);
        }


        [Test]
        public void RemoveProjectTest()
        {
            try
            {
                var user = new User
                {
                    Login = "krukelenka84@gmail.com",
                    Password = "krukelenka84"
                };
                var project = new Project { Name = "TMS" };

                if (!_loginSteps.SuccessfulLogin(user).IsPageOpened)
                    throw new Exception("Home page not opened!");

                _projectSteps.ProjectsPage.OpenPageByURL();
                if (!_projectSteps.ProjectsPage.IsPageOpened)
                    throw new Exception("Page not opened!");

                var projectId = _projectSteps.RemoveProject(project);
                var deleteIcon = _projectSteps.ProjectsPage.FindHiddenDeleteIconByProjectId(projectId);

                Assert.IsTrue(deleteIcon != null);


                //var displayed = deleteIcon.Displayed;
                //var iconClass = deleteIcon.GetAttribute("class");
                //Assert.IsTrue(iconClass.Contains("default-hidden"));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}
