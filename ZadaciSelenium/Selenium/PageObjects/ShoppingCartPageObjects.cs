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
    class ShoppingCartPageObjects
    {

        private IWebDriver driver;


        public ShoppingCartPageObjects(IWebDriver _driver) => driver = _driver;


        public IWebElement txtEnterQuantity => driver.FindElement(By.Name("quantity_1_1_0_419123"));


        public IWebElement btnProcedToCheckout => driver.FindElement(By.LinkText("Proceed to checkout"));



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

        public void AddQuantity(string quantity)
        {
            try
            {
                ElementPresent(txtEnterQuantity);
                ElementEnabled(txtEnterQuantity);
                ElementEmpty(txtEnterQuantity);
                SeleniumSetMethod.EnterText(txtEnterQuantity, quantity);

                ElementPresent(btnProcedToCheckout);
                ElementEnabled(btnProcedToCheckout);
                SeleniumSetMethod.Submits(btnProcedToCheckout);

                string urlAdress = driver.Url;
                SeleniumSetMethod.WaitForPageToLoad(driver, 35);
                SeleniumGetMethods.PageLoaded(urlAdress, "Order - My Store");
                Console.WriteLine("Product quantity increased successfully!");
            }
            catch (Exception e)
            {

                Console.WriteLine("Adding Product quantity failed: {0}", e);
            }
        }       
    }
}
