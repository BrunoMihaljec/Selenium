using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selenium.Methods
{
    public class SeleniumGetMethods
    {

        public static string GetText(IWebElement element)
        {
            return element.GetAttribute("value");

        }

        public static void PageLoaded(string url, string condition)
        {
            try
            {
                // Assert is true and page is loaded
                Assert.IsTrue(url.Contains(condition), condition);
                Console.WriteLine("Correct page loaded!");
            }
            catch (Exception e)
            {
                // Assert is false wrong page is loaded!
                Console.WriteLine("Wrong page loaded {0}!", e);
            }
           
        }


    }
}
