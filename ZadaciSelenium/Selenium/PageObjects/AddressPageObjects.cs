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
    class AddressPageObjects
    {
        private IWebDriver driver;


        public AddressPageObjects(IWebDriver _driver) => driver = _driver;


        public IWebElement txtComment => driver.FindElement(By.Name("message"));


        public IWebElement btnProcedToAddress => driver.FindElement(By.Name("processAddress"));



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

        public void AddComment(string comment)
        {
            try
            {
                ElementPresent(txtComment);
                ElementEnabled(txtComment);
                ElementEmpty(txtComment);
                SeleniumSetMethod.EnterText(txtComment, comment);

                ElementPresent(btnProcedToAddress);
                ElementEnabled(btnProcedToAddress);
                SeleniumSetMethod.Submits(btnProcedToAddress);

                string urlAdress = driver.Url;
                SeleniumSetMethod.WaitForPageToLoad(driver, 35);
                SeleniumGetMethods.PageLoaded(urlAdress, "Order - My Store");
                Console.WriteLine("Comment added successfully!");
            }
            catch (Exception e)
            {

                Console.WriteLine("Adding Product quantity failed: {0}", e);
            }
        }
    }
}
