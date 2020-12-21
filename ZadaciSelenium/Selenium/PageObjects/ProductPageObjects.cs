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
    class ProductPageObjects
    {

        private IWebDriver driver;


        public ProductPageObjects(IWebDriver _driver) => driver = _driver;


        public IWebElement btnAddToCart => driver.FindElement(By.Name("Submit"));


        public IWebElement btnGoToCheckout => driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[2]/div[4]/a"));



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

        public void AddToCart()
        {
            try
            {
                ElementPresent(btnAddToCart);
                ElementEnabled(btnAddToCart);
                SeleniumSetMethod.Submits(btnAddToCart);

                ElementPresent(btnGoToCheckout);
                ElementEnabled(btnGoToCheckout);
                SeleniumSetMethod.Submits(btnGoToCheckout);

                string urlShoppingCart = driver.Url;
                SeleniumSetMethod.WaitForPageToLoad(driver, 35);
                SeleniumGetMethods.PageLoaded(urlShoppingCart, "Order - My Store");
                Console.WriteLine("Product added successfully!");
            }
            catch (Exception e)
            {

                Console.WriteLine("Adding product failed: {0}", e);
            }
        }
        
    }
}
