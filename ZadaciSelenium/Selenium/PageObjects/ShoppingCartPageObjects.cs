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
    static class ShoppingCartPageObjects
    {

        private static IWebDriver driver = WebDriver.driver;

        public static IWebElement txtEnterQuantity = WebDriver.driver.FindElement(By.Name("quantity_1_1_0_419123"));


        public static IWebElement btnProcedToCheckout = WebDriver.driver.FindElement(By.LinkText("Proceed to checkout"));



        public static void AddQuantity(string quantity)
        {
            try
            {
                SeleniumSetMethod.ElementPresent(txtEnterQuantity);
                SeleniumSetMethod.ElementEnabled(txtEnterQuantity);
                txtEnterQuantity.Clear();
                SeleniumSetMethod.ElementEmpty(txtEnterQuantity);
                SeleniumSetMethod.EnterText(txtEnterQuantity, quantity);

                SeleniumSetMethod.ElementPresent(btnProcedToCheckout);
                SeleniumSetMethod.ElementEnabled(btnProcedToCheckout);
                SeleniumSetMethod.Clicks(btnProcedToCheckout);

                string urlAdress = driver.Url;
                SeleniumSetMethod.WaitForPageToLoad(driver, 35);
                SeleniumGetMethods.PageLoaded(urlAdress, "order");
                Console.WriteLine("Product quantity increased successfully!");
            }
            catch (Exception e)
            {

                Console.WriteLine("Adding Product quantity failed: {0}", e);
            }
        }       
    }
}
