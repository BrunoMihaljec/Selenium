using OpenQA.Selenium;
using Selenium;
using System;
using Selenium.Web_Driver;
using Selenium.Methods;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Selenium.PageObjects
{
    static class SearchPageObject
    {

        public static IWebElement txtSearch => WebDriver.driver.FindElement(By.Name("search_query"));


        public static IWebElement btnSearch => WebDriver.driver.FindElement(By.Name("submit_search"));



        public static void EnterProduct(string search)
        {
            try
            {
                SeleniumSetMethod.ElementPresent(txtSearch);
                SeleniumSetMethod.ElementEnabled(txtSearch);
                SeleniumSetMethod.ElementEmpty(txtSearch);
                SeleniumSetMethod.EnterText(txtSearch, search);

                SeleniumSetMethod.ElementPresent(btnSearch);
                SeleniumSetMethod.ElementEnabled(btnSearch);
                SeleniumSetMethod.Submits(btnSearch);

                string urlProducts = WebDriver.driver.Url;
                SeleniumSetMethod.WaitForPageToLoad(WebDriver.driver, 50);
                SeleniumGetMethods.PageLoaded(urlProducts, "shirt");
                Console.WriteLine("Search successful!");
            }
            catch (Exception e)
            {

                Console.WriteLine("Search failed: {0}", e);
            }
        }      
    }
}
