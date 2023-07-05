using DiplomaProject.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject.Steps
{
    public abstract class BaseStep
    {
        public BaseStep(IWebDriver driver)
        {
            _driver = driver;
        }


        protected IWebDriver _driver;
    }
}
