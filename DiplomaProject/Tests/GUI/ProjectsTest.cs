using Allure.Commons;
using DiplomaProject.Models;
using DiplomaProject.Pages;
using DiplomaProject.Steps;
using DiplomaProject.Utilities.Configuration;
using NUnit.Allure.Attributes;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject.Tests.UI
{
    public class ProjectsTest : BaseGuiTest
    {
        [Test, Category ("Positive")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Gui")]
        [AllureIssue(name: "ID_3")]
        [AllureTag("Smoke")]
        [AllureLink("https://elenkakruk.testmo.net/")]
        [Description("Проверка ввода превышающего значения 81 ")]
        public void CheckLimitValue_1()
        {
            if (!_loginSteps.SuccessfulLogin(Configurator.Instance.User).IsPageOpened)
                throw new Exception("Main page not opened!");

            var projectsPage = new ProjectsPage(_driver, true);
            projectsPage.AddProjectButton.Click();

            var summaryInput = projectsPage.SummaryTextArea;
            var expected = new string('+', 80);
            summaryInput.SendKeys(expected + '=');

            Assert.That(summaryInput.Value, Is.EqualTo(expected));
        }

        [Test]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Gui")]
        [AllureIssue(name: "ID_4")]
        [AllureTag("Smoke")]
        [AllureLink("https://elenkakruk.testmo.net/")]
        [Description("Проверка ввода  граничного значения 0")]
        public void CheckLimitValue_2()
        {
            if (!_loginSteps.SuccessfulLogin(Configurator.Instance.User).IsPageOpened)
                throw new Exception("Main page not opened!");

            var projectsPage = new ProjectsPage(_driver, true);
            projectsPage.AddProjectButton.Click();

            var summaryInput = projectsPage.SummaryTextArea;
            summaryInput.SendKeys("");

            Assert.That(summaryInput.Value.Length, Is.EqualTo(0));
        }

        [Test]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Gui")]
        [AllureIssue(name: "ID_5")]
        [AllureTag("Smoke")]
        [AllureLink("https://elenkakruk.testmo.net/")]
        [Description ("Проверка отображения диалогового окна")]
        public void CheckModalWindow()
        {
            try
            {
                if (!_loginSteps.SuccessfulLogin(Configurator.Instance.User).IsPageOpened)
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
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Gui")]
        [AllureIssue(name: "ID_6")]
        [AllureTag("Smoke")]
        [AllureLink("https://elenkakruk.testmo.net/")]
        [Description("Проверка добавления проекта")]
        public void AddProjectTest()
        {
            if (!_loginSteps.SuccessfulLogin(Configurator.Instance.User).IsPageOpened)
                throw new Exception("Main page not opened!");

            var model = new Project { Name = "TMS" };
            _projectSteps.AddProject(model);

            var tableElement = _projectSteps.ProjectsPage.GetTableRowByProjectName(model.Name);

            Assert.IsTrue(tableElement != null);
        }

        [Test]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Gui")]
        [AllureIssue(name: "ID_7")]
        [AllureTag("Smoke")]
        [AllureLink("https://elenkakruk.testmo.net/")]
        [Description("Проверка отображения всплывающего сообщения")]
        public void CheckTooltip()
        {
            try
            {
                if (!_loginSteps.SuccessfulLogin(Configurator.Instance.User).IsPageOpened)
                    throw new Exception("Main page not opened!");

                var projectsPage = new ProjectsPage(_driver, true);
                projectsPage.AddProjectButton.Click();
                projectsPage.DefaultAccessTooltip.Click();

                string content = projectsPage.DefaultAccessTooltip.GetAttribute("data-content");
                var tooltip = projectsPage.GetTooltipByContent(content); ;

                Assert.IsTrue(tooltip != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Gui")]
        [AllureIssue(name: "ID_8")]
        [AllureTag("Smoke")]
        [AllureLink("https://elenkakruk.testmo.net/")]
        [Description("Проверка успешной загрузки файла")]
        public void SuccecfulLoadingFile()
        {
            if (!_loginSteps.SuccessfulLogin(Configurator.Instance.User).IsPageOpened)
                throw new Exception("Main page not opened!");

            var projectsPage = new ProjectsPage(_driver, true);
            projectsPage.AddProjectButton.Click();
            projectsPage.SelectButton.Click();
            projectsPage.SelectFileInput.SendKeys(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                + Path.DirectorySeparatorChar + "picture.png"
            );

            var avatar = projectsPage.CustomAvatarImage;
            var src = avatar.GetAttribute("src");

            Assert.IsTrue(avatar != null);
        }

        [Test]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("Gui")]
        [AllureIssue(name: "ID_9")]
        [AllureTag("Smoke")]
        [AllureLink("https://elenkakruk.testmo.net/")]
        [Description("Проверка успешной загрузки файла")]
        public void RemoveProjectTest()
        {
            try
            {
                var project = new Project { Name = "TMS" };

                if (!_loginSteps.SuccessfulLogin(Configurator.Instance.User).IsPageOpened)
                    throw new Exception("Home page not opened!");

                _projectSteps.ProjectsPage.OpenPageByURL();
                if (!_projectSteps.ProjectsPage.IsPageOpened)
                    throw new Exception("Page not opened!");

                var projectId = _projectSteps.RemoveProject(project);
                var deleteIcon = _projectSteps.ProjectsPage.FindHiddenDeleteIconByProjectId(projectId);

                Assert.IsTrue(deleteIcon != null);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        //[Test, Category ("Failed")]
        //[AllureTag("Regression")]
        //[AllureSeverity(SeverityLevel.critical)]
        //[AllureOwner("User")]
        //[AllureSuite("PassedSuite")]
        //[AllureSubSuite("Gui")]
        //[AllureIssue(name: "ID_9")]
        //[AllureTag("Smoke")]
        //[AllureLink("https://elenkakruk.testmo.net/")]
        //[Description("Проверка успешной загрузки файла")]
        //public void SuccecfulLoadingFile_2()
        //{
        //    if (!_loginSteps.SuccessfulLogin(Configurator.Instance.User).IsPageOpened)
        //        throw new Exception("Main page not opened!");

        //    var projectsPage = new ProjectsPage(_driver, true);
        //    projectsPage.AddProjectButton.Click();
        //    projectsPage.SelectButton.Click();
        //    projectsPage.SelectFileInput.SendKeys(
        //        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
        //        + Path.DirectorySeparatorChar + "picture.png"
        //    );

        //    var avatarSrc = projectsPage.CustomAvatarImage;
        //    Assert.IsFalse(avatarSrc != null);
        //}
    }
}
