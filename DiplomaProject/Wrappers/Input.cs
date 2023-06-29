using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject.Wrappers
{
    public class Input
    {
        private readonly IWebElement _element;

        public Input(IWebElement element)
        {
            _element = element;
        }

        public bool Displayed => _element.Displayed;

        public string Text => _element.Text;


        public void Click()
        {
            _element.Click();
        }

        public void SendKeys(string text)
        {
            _element.SendKeys(text);
        }
    }
}

