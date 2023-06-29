using DiplomaProject.Core;
using DiplomaProject.Utilities.Configuration;
using OpenQA.Selenium;

namespace DiplomaProject.Pages
{
    public abstract class BasePage
    {
        public abstract bool IsPageOpened { get; }
        protected abstract string Endpoint { get; }


        protected IWebDriver _driver;
        protected WaitService _waitService;

        
        public BasePage(IWebDriver driver, bool openPageByURL = false)
        { 
            _driver = driver;
            _waitService = new WaitService(driver);

            if(openPageByURL )
            {
                OpenPageByURL();
            }
        }

        private void OpenPageByURL()
        {
            _driver.Navigate().GoToUrl(Configurator.AppSettings.URL + Endpoint);
        } 
    }
}
