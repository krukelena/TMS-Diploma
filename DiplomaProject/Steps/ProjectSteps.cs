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
    public class ProjectSteps : BaseStep
    {
        public ProjectSteps(IWebDriver driver) : base(driver) { 
            ProjectsPage = new ProjectsPage(driver);
        }


        public ProjectsPage ProjectsPage;


        public void AddProject(Project project)
        {
            ProjectsPage.OpenPageByURL();

            if (!ProjectsPage.IsPageOpened)
                throw new Exception("Page not opened!");

            ProjectsPage.AddProjectButton.Click();

            var nameInput = _driver.FindElement(By.XPath("//input[@data-target='name']"));
            nameInput.SendKeys(project.Name);

            var addButton = _driver.FindElement(By.XPath("//button[@data-target='submitButton']"));
            addButton.Click();
        }

        public bool RemoveProject(Project project)
        {
            ProjectsPage.OpenPageByURL();

            if (!ProjectsPage.IsPageOpened)
                throw new Exception("Page not opened!");

            var tableRow = _driver.FindElement(By.XPath($"//tr[@data-name='{project.Name}']"));
            var deleteIcon = tableRow.FindElement(ProjectsPage.DeleteIconBy);
            deleteIcon.Click();

            ProjectsPage.DeleteCheckbox.Click();
            ProjectsPage.DeleteButton.Click();

            return deleteIcon.Displayed;
        }
    }
}
