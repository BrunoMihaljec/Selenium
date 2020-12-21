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
    class ShippingPageObjects
    {
        private IWebDriver driver;


        public ShippingPageObjects(IWebDriver _driver) => driver = _driver;


        public IWebElement chcbxIAgree => driver.FindElement(By.Name("cgv"));


        public IWebElement btnProccedToPayment => driver.FindElement(By.Name("processCarrier"));



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

        public void GoToPayment()
        {
            try
            {
                ElementPresent(chcbxIAgree);
                ElementEnabled(chcbxIAgree);
                SeleniumSetMethod.CheckBox(chcbxIAgree);

                ElementPresent(btnProccedToPayment);
                ElementEnabled(btnProccedToPayment);
                SeleniumSetMethod.Submits(btnProccedToPayment);

                string urlAdress = driver.Url;
                SeleniumSetMethod.WaitForPageToLoad(driver, 35);
                SeleniumGetMethods.PageLoaded(urlAdress, "Order - My Store");
                Console.WriteLine("Procceded to payment successfully!");
            }
            catch (Exception e)
            {

                Console.WriteLine("Adding Product quantity failed: {0}", e);
            }
        }

        /*
        public ShippingPageObjects()
        {
            PageFactory.InitElements(WebDriver.driver, this);
        }

        [FindsBy(How = How.Name, Using = "cgv")]
        public IWebElement chcbxIAgree { get; set; }


        [FindsBy(How = How.Name, Using = "processCarrier")]
        public IWebElement btnProccedToPayment { get; set; }



        public void FillShipping()
        {

            chcbxIAgree.Clicks();
            btnProccedToPayment.Clicks();

        }*/
    }
}
