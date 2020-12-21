using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Selenium;
using System;
using Selenium.Web_Driver;
using Selenium.Methods;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Selenium.PageObjects
{
    class SearchPageObject
    {
        private IWebDriver driver;


        public SearchPageObject(IWebDriver _driver) => driver = _driver;


        public IWebElement txtSearch => driver.FindElement(By.Name("search_query"));


        public IWebElement btnSearch => driver.FindElement(By.Name("submit_search"));


        public void ElementPresent(IWebElement element)
        {
            try
            {
                //Print message if assert pass
                Assert.IsTrue(element.Displayed);
                Console.WriteLine("Element is displayed!");
            }
            catch (Exception e)
            {
                //Printing message if assert is fails
                Console.WriteLine("Element does not exist: {0}", e);
            }
        }


        public void ElementEmpty(IWebElement element)
        {

            string text = element.GetAttribute("value");

            try
            {
                //Print message if assert pass
                Assert.IsEmpty(text);
                Console.WriteLine("Element is empty!");
            }
            catch (Exception e)
            {
                //Printing message if assert is fails
                Console.WriteLine("Element is not empty: {0}", e);
            }
        }
        public void ElementEnabled(IWebElement element)
        {
            try
            {
                //Print message if assert pass
                Assert.IsTrue(element.Enabled);
                Console.WriteLine("Element is enabled!");
            }
            catch (Exception e)
            {
                //Printing message if assert is fails
                Console.WriteLine("Element is not enabled: " + e);
            }

        }


        public void EnterProduct(string search)
        {
            try
            {
                ElementPresent(txtSearch);
                ElementEnabled(txtSearch);
                ElementEmpty(txtSearch);
                SeleniumSetMethod.EnterText(txtSearch, search);

                ElementPresent(btnSearch);
                ElementEnabled(btnSearch);
                SeleniumSetMethod.Submits(btnSearch);

                string urlProducts = driver.Url;
                SeleniumSetMethod.WaitForPageToLoad(driver, 35);
                SeleniumGetMethods.PageLoaded(urlProducts, "Search - My Store");
                Console.WriteLine("Search successful!");
            }
            catch (Exception e)
            {

                Console.WriteLine("Search failed: {0}", e);
            }
        }      
    }
}
