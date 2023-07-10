using DiplomaProject.Models;
using DiplomaProject.Wrappers;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject.Pages
{
   public class ProjectsPage :  BasePage
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private static readonly By AddProjectButtonBy = By.XPath("//button[@data-target='admin--projects--index.addButton']");
        private static readonly By SummaryTextAreaBy = By.XPath("//textarea");
        private static readonly By DefaultAccessTooltipBy = By.XPath("//div[@data-title='Default access']");
        private static readonly By SelectButtonBy = By.XPath("//button[@dusk='selectAvatarButton']");
        private static readonly By SelectFileInputBy = By.XPath("//input[@data-target='fileInput']");
        private static readonly By AvatarImageBy = By.XPath("//div[@class='avatar avatar--project  avatar--64     ']/img");
        private static readonly By CustomAvatarImageBy = By.XPath("//div[@class='avatar avatar--project  avatar--64     ']/img[contains(@src, 'attachments/view')]");

        public static readonly By DeleteIconBy = By.XPath(".//div[@data-action='delete' and @class='tooltip']");
        public static readonly By HiddenDeleteIconBy = By.XPath(".//div[contains(@class, 'default-hidden')]");
        public static readonly By DeleteCheckboxBy = By.XPath("//label[@data-target='confirmationLabel']");
        public static readonly By DeleteButtonBy = By.XPath("//button[@data-target='deleteButton']");



        public ProjectsPage(IWebDriver driver, bool openPageByURL = false) : base(driver, openPageByURL)
        {
            _logger.Info("Перехожу со страницы LoginPage на страницу  ProjectsPage");
        }

        public override bool IsPageOpened => _waitService.GetVisibleElement(AddProjectButtonBy) != null;

        protected override string Endpoint => "admin/projects";

        public Button AddProjectButton => new Button(_driver.FindElement(AddProjectButtonBy));
        public TextArea SummaryTextArea => new TextArea(_driver.FindElement(SummaryTextAreaBy));
        public IWebElement DefaultAccessTooltip => _driver.FindElement(DefaultAccessTooltipBy);
        public IWebElement SelectButton => _driver.FindElement(SelectButtonBy);
        public Input SelectFileInput => new Input(_driver.FindElement(SelectFileInputBy));
        public IWebElement AvatarImage => _driver.FindElement(AvatarImageBy);
        public IWebElement CustomAvatarImage => _waitService.GetVisibleElement(CustomAvatarImageBy);


        public IWebElement DeleteCheckbox => _driver.FindElement(DeleteCheckboxBy);
        public Button DeleteButton => new Button(_driver.FindElement(DeleteButtonBy));


        public IWebElement GetTableRowByProjectName(string projectName)
        {
            return _driver.FindElement(By.XPath($"//tr[@data-name='{projectName}']"));
        }

        public IWebElement FindHiddenDeleteIconByProjectId(string projectId)
        {
            return _waitService.SearchElement(
                By.XPath($"//tr[@data-id='{projectId}']/td[4]/div[contains(@class, 'default-hidden')]")
            );
        }
    }
}
