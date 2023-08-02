using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaProject.Wrappers
{
    public class Button
    { 
        private readonly IWebElement _element;

        public Button (IWebElement element)
        {
            _element = element;
        }


        public bool Displayed => _element.Displayed;

        public string Text => _element.Text;


        public void Click()
        {
            _element.Click();
        }    
    }
}
