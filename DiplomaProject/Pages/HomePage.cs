using AngleSharp.Html.Dom;
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
    public class HomePage : BasePage
    {
       
        private static readonly By AddProjectButtonBy = By.XPath("//button[@data-target='home--index.addButton']");

        public HomePage(IWebDriver driver, bool openPageByURL = false) : base(driver, openPageByURL)
        {
            
        }


        public override bool IsPageOpened => _waitService.GetVisibleElement(AddProjectButtonBy) != null;

        protected override string Endpoint => "";

        public Button AddProjectButton => new Button (_driver.FindElement(AddProjectButtonBy));
    }
}
