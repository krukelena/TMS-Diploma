using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace DiplomaProject.Core
{
    public class WaitService
    {


        [ThreadStatic] protected static IWebDriver? _driver;

        private WebDriverWait _wait;

        public WaitService(IWebDriver? driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }


        public IWebElement? SearchElement(By by)
        {
            try
            {
                return _wait.Until(x => x.FindElement(by));
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public IWebElement? GetVisibleElement(By by)
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IAlert GetAlertOnPage()
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return _wait.Until(ExpectedConditions.AlertIsPresent());
        }

        public IWebElement ExistsElement(By by)
        {
            var fluentWait = new DefaultWait<IWebDriver?>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return fluentWait.Until(ExpectedConditions.ElementIsVisible(by));
        }
    }
}
        
    

