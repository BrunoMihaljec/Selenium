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
    static class ShippingPageObjects
    {
        private static IWebDriver driver = WebDriver.driver;

        public static IWebElement chcbxIAgree = WebDriver.driver.FindElement(By.Id("cgv"));


        public static IWebElement btnProccedToPayment = WebDriver.driver.FindElement(By.Name("processCarrier"));

        

        public static void GoToPayment()
        {
            try
            {
                //driver.SwitchTo().Frame("carrier_area");
                SeleniumSetMethod.ElementPresent(chcbxIAgree);
               // driver.SwitchTo().ParentFrame();
                SeleniumSetMethod.ElementEnabled(chcbxIAgree);
                SeleniumSetMethod.CheckBox(chcbxIAgree);

                SeleniumSetMethod.ElementPresent(btnProccedToPayment);
                SeleniumSetMethod.ElementEnabled(btnProccedToPayment);
                SeleniumSetMethod.Clicks(btnProccedToPayment);

                string urlAdress = driver.Url;
                SeleniumSetMethod.WaitForPageToLoad(driver, 35);
                SeleniumGetMethods.PageLoaded(urlAdress, "shipping");
                Console.WriteLine("Procceded to payment successfully!");
            }
            catch (Exception e)
            {

                Console.WriteLine("Adding Product quantity failed: {0}", e);
            }
        }

        
    }
}
