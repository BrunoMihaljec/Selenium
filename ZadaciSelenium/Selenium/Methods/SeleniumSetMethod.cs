using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Selenium.Web_Driver;

namespace Selenium.Methods
{


    public class SeleniumSetMethod
    {

        public static void EnterText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        public static void Clicks(IWebElement element)
        {
            element.Click();
        }

        public static void SelectDropDown(IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }

        public static void Submits(IWebElement element)
        {
            element.Submit();
        }

        public static void CheckBox(IWebElement element)
        {
            element.Click();
        }

        public static void WaitForPageToLoad(IWebDriver driver, int seconds)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(seconds)).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        
    }
}
