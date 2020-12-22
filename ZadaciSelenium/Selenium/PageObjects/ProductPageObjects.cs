using OpenQA.Selenium;
using Selenium;
using System;
using Selenium.Web_Driver;
using Selenium.Methods;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Threading;

namespace Selenium.PageObjects
{
    static class ProductPageObjects
    {

        private static IWebDriver driver = WebDriver.driver;

        public static IWebElement btnAddToCart = WebDriver.driver.FindElement(By.Name("Submit"));


        public static IWebElement btnGoToCheckout = WebDriver.driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[2]/div[4]/a"));



        public static void AddToCart()
        {
            try
            {
                SeleniumSetMethod.ElementPresent(btnAddToCart);
                SeleniumSetMethod.ElementEnabled(btnAddToCart);
                SeleniumSetMethod.Clicks(btnAddToCart);
                Thread.Sleep(3000);

                SeleniumSetMethod.ElementPresent(btnGoToCheckout);
                SeleniumSetMethod.ElementEnabled(btnGoToCheckout);
                SeleniumSetMethod.Clicks(btnGoToCheckout);

                string urlShoppingCart = driver.Url;
                SeleniumSetMethod.WaitForPageToLoad(driver, 35);
                SeleniumGetMethods.PageLoaded(urlShoppingCart, "order");
                Console.WriteLine("Product added successfully!");
            }
            catch (Exception e)
            {

                Console.WriteLine("Adding product failed: {0}", e);
            }
        }
        
    }
}
