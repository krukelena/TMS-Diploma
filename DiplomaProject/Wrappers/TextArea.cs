using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject.Wrappers
{
    public class TextArea
    {
        private readonly IWebElement _element;

        public TextArea(IWebElement element)
        {
            _element = element;
        }

        public bool Displayed => _element.Displayed;
        public string Value => _element.GetAttribute("value");

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

