using OpenQA.Selenium;
using Selenium;
using System;
using Selenium.Web_Driver;
using Selenium.Methods;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace Selenium.PageObjects
{
    static class ShoppingPageObjects
    {
        private static IWebDriver driver = WebDriver.driver;

        public static IWebElement btnGoToProduct = WebDriver.driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div[1]/div[1]/div/ul/li[2]/div/h5/a"));

   

        public static void SelectProduct()
        {
            try
            {             

                SeleniumSetMethod.ElementPresent(btnGoToProduct);
                SeleniumSetMethod.ElementEnabled(btnGoToProduct);
                SeleniumSetMethod.Clicks(btnGoToProduct);

                string urlSelectedProduct = driver.Url;
                SeleniumSetMethod.WaitForPageToLoad(driver, 50);
                SeleniumGetMethods.PageLoaded(urlSelectedProduct, "product");
                Console.WriteLine("Viewing product successful!");
            }
            catch (Exception e)
            {

                Console.WriteLine("Viewing product failed: {0}", e);
            }
        }


        
    }
}
