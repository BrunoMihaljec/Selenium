using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
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
    class ShoppingPageObjects
    {
        private IWebDriver driver;


        public ShoppingPageObjects(IWebDriver _driver) => driver = _driver;


        public IWebElement btnGoToProduct => driver.FindElement(By.LinkText("Faded Short Sleeve T-shirts"));


        public IWebElement ddlSortBy => driver.FindElement(By.Id("selectProductSort"));



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

        public void SortAndSelectProduct(string sortBy)
        {
            try
            {
                ElementPresent(ddlSortBy);
                ElementEnabled(ddlSortBy);
                ElementEmpty(ddlSortBy);
                SeleniumSetMethod.SelectDropDown(ddlSortBy, sortBy);

                ElementPresent(btnGoToProduct);
                ElementEnabled(btnGoToProduct);
                SeleniumSetMethod.Submits(btnGoToProduct);

                string urlSelectedProduct = driver.Url;
                SeleniumSetMethod.WaitForPageToLoad(driver, 35);
                SeleniumGetMethods.PageLoaded(urlSelectedProduct, "Faded Short Sleeve T-shirts - My Store");
                Console.WriteLine("Viewing product successful!");
            }
            catch (Exception e)
            {

                Console.WriteLine("Viewing product failed: {0}", e);
            }
        }


        
    }
}
